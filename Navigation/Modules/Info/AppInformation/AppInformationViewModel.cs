using Navigation.Common.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Navigation.Modules.Info.AppInformation
{
    public class AppInformationViewModel : BaseViewModel
    {
        public string AppName => $"App Name: {AppInfo.Name}";
        public string AppVersion => $"App Version: {AppInfo.VersionString}";
        public string Author => "Author: c0ff33-b34n";
    }
}
