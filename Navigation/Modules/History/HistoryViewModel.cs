using Navigation.Common.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Navigation.Modules.History
{
    public class HistoryViewModel : BaseViewModel
    {
        public HistoryViewModel()
        {
            Items = new ObservableCollection<string>
            {
                "44 + 5 = 49",
                "36 / 9 = 4",
                "21 + 4 = 84"
            };
        }

        public ObservableCollection<string> Items { get; set; }

        public ICommand DeleteCommand
        {
            get => new Command<string>(deleteItem);
        }

        private void deleteItem(string item)
        {
            Items.Remove(item);
        }
    }
}
