using Navigation.Common.Navigation;
using Navigation.Modules.History;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Navigation
{
    public enum CalculatorState
    {
        PopulatingFirstNumber,
        PopulatingSecondNumber
    }

    public enum Operation
    {
        None,
        Add,
        Subtract,
        Divide,
        Multiply,
        Equal
    }

    public class CalculatorViewModel: BindableObject
    {
        private string _displayText;
        private string _firstNumber = string.Empty;
        private string _secondNumber = string.Empty;
        private CalculatorState _state;
        private Operation _currentOperation;
        private INavigationService _navigation;
        private List<string> _calculatorHistory = new List<string>();

        public CalculatorViewModel(INavigationService navigation)
        {
            _state = CalculatorState.PopulatingFirstNumber;
            _currentOperation = Operation.None;
            _navigation = navigation;
        }

        public string DisplayText
        {
            get => _displayText; 
            set
            {
                _displayText = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowHistoryCommand => new Command(async () => { await GoToHistory(); });

        private async Task GoToHistory()
        {
            await _navigation.PushAsync<HistoryViewModel>(_calculatorHistory);
        }

        public ICommand ClearCommand => new Command(ClearText);

        public ICommand AddCharCommand => new Command<string>(AddChar);

        public ICommand OperationCommand => new Command<Operation>(PerformOperation);

        private void AddChar(string character)
        {
            if (_state == CalculatorState.PopulatingFirstNumber)
            {
                if (_firstNumber.Contains(",") && character == ",")
                {
                    return;
                }
                _firstNumber += character;
                DisplayText = _firstNumber;
                _currentOperation = Operation.None;
                return;
            }

            if (_secondNumber.Contains(",") && character == ",")
            {
                return;
            }
            _secondNumber += character;
            DisplayText = _secondNumber;
        }

        private void ClearText()
        {
            if (_state == CalculatorState.PopulatingFirstNumber)
            {
                _firstNumber = string.Empty;
            }
            else
            {
                _firstNumber = string.Empty;
                _secondNumber = string.Empty;
                _state = CalculatorState.PopulatingFirstNumber;
            }
            _currentOperation = Operation.None;
            DisplayText = string.Empty;
        }

        private void PerformOperation(Operation operation)
        {
            if (string.IsNullOrWhiteSpace(_firstNumber))
            {
                _currentOperation = Operation.None;
                return;
            }
            if (operation == Operation.Equal && 
                !string.IsNullOrWhiteSpace(_firstNumber) &&
                !string.IsNullOrWhiteSpace(_secondNumber))
            {
                Calculate();
                _currentOperation = Operation.None;
                return;
            }
            if (operation != Operation.None &&
                !string.IsNullOrWhiteSpace(_firstNumber) &&
                !string.IsNullOrWhiteSpace(_secondNumber))
            {
                Calculate();
                _currentOperation = operation;
                return;
            }
            _currentOperation = operation;
            DisplayText = string.Empty;
            _state = CalculatorState.PopulatingSecondNumber;
        }

        private void Calculate()
        {
            var first = decimal.Parse(_firstNumber);
            var second = decimal.Parse(_secondNumber);
            decimal result = 0;
            switch (_currentOperation)
            {
                case Operation.Add:
                    result = first + second;
                    break;
                case Operation.Subtract:
                    result = first - second;
                    break;
                case Operation.Divide:
                    result = first / second;
                    break;
                case Operation.Multiply:
                    result = first * second;
                    break;
                default:
                    break;
            }
            DisplayText = result.ToString();
            _calculatorHistory.Add($"{_firstNumber} {GetOperationString()} {_secondNumber} = {result}");
            _state = CalculatorState.PopulatingSecondNumber;
            _firstNumber = result.ToString();
            _secondNumber = string.Empty;
        }

        private object GetOperationString()
        {
            return _currentOperation switch
            {
                Operation.Add => "+",
                Operation.Subtract => "-",
                Operation.Divide => "/",
                Operation.Multiply => "*",
                _ => ""
            };
        }
    }
}
