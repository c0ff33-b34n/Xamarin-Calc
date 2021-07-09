﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Navigation.Common.Navigation
{
    public interface INavigationService
    {
        Task PushAsync<TViewModel>(object parameter = null) where TViewModel: BaseViewModel;
        Task PopAsync();
    }
}
