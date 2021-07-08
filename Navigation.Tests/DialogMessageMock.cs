using System.Threading.Tasks;

namespace Navigation.Tests
{
    class DialogMessageMock : IDialogMessage
    {
        public int DisplayAlertCallCount { get; set; }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            DisplayAlertCallCount++;
            return Task.CompletedTask;
        }
    }
}
