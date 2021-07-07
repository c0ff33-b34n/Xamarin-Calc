using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Navigation
{
    public interface IDialogMessage
    {
        Task DisplayAlert(string title, string message, string cancel);
    }
}
