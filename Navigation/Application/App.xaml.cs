using Autofac;
using Navigation.Common.Navigation;
using Navigation.Modules.History;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // create Autofac DI ContainerBuilder
            var builder = new ContainerBuilder();
            // scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                .AsImplementedInterfaces()
                .AsSelf();

            NavigationPage navigationPage = null;

            Func<INavigation> navigationFunc = () =>
            {
                return navigationPage.Navigation;
            };

            builder.RegisterType<NavigationService>().As<INavigationService>()
                .WithParameter("navigation", navigationFunc);

            // get container
            var container = builder.Build();

            navigationPage = new NavigationPage(container.Resolve<CalculatorView>());

            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
