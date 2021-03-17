using AMS.Mobile.Interfaces;
using AMS.Mobile.Services;
using AMS.Mobile.ViewModels;
using AMS.Mobile.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace AMS.Mobile
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<TractorDetailsPage, TractorDetailsPageViewModel>();

            RegisterServices(containerRegistry);
        }

        private void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterScoped<ITractorInfoService, TractorInfoService>();
        }
    }
}
