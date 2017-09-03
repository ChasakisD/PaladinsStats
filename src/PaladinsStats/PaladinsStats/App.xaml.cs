using PaladinsStats.Business.Interfaces;
using PaladinsStats.Business.Managers;
using PaladinsStats.Business.Services;
using Prism.Unity;
using PaladinsStats.Views;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace PaladinsStats
{
    public partial class App
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<PlayerOverviewPage>();

            var connectionService = DependencyService.Get<ISqliteConnectionService>();

            Container.RegisterInstance(connectionService, new ContainerControlledLifetimeManager());
            Container.RegisterType<IPaladinsStatsRestService, PaladinsStatsRestService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IPaladinsStatsDataAccessService, PaladinsStatsDataAccessService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IPaladinsStatsManager, PaladinsStatsManager>(new ContainerControlledLifetimeManager());
            
        }
    }
}
