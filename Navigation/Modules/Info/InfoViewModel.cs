using Navigation.Common.Navigation;
using Navigation.Modules.History;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Navigation.Modules.Info
{
    public class InfoViewModel : BaseViewModel
    {
        public InfoViewModel(HistoryViewModel historyViewModel)
        {
            HistoryViewModel = historyViewModel;
        }

        public HistoryViewModel HistoryViewModel { get; set; }
        public override Task InitializeAsync(object parameter)
        {
            return HistoryViewModel.InitializeAsync(parameter);
        }
    }
}
