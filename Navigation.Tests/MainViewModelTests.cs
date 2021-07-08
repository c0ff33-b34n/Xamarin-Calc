using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Navigation.Tests
{
    public class MainViewModelTests
    {
        [Fact]
        public void DisplayAlertCommand_displays_alert()
        {
            var dialogMessage = new DialogMessageMock();
            var viewModel = new MainViewModel(dialogMessage);

            viewModel.DisplayAlertCommand.Execute(null);

            Assert.Equal(1, dialogMessage.DisplayAlertCallCount);
        }
    }
}
