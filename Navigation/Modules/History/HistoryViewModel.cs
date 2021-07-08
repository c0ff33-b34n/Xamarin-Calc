using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Navigation.Modules.History
{
    public class HistoryViewModel
    {
        public ObservableCollection<string> Items => new ObservableCollection<string>
        {
            "44 + 5 = 49",
            "36 / 9 = 4",
            "21 + 4 = 84"
        };
    }
}
