using AMS.Mobile.Constants;
using AMS.Mobile.Extensions;
using AMS.Mobile.Models;
using AMS.Mobile.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AMS.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<TractorInfo> Items { get; }

        public ICommand RefreshCommand { get; set; }
        public ICommand OpenInfoPageCommand { get; set; }
        

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Items = new ObservableCollection<TractorInfo>();

            RefreshCommand = new DelegateCommand(async () => await ExecuteRefreshAsync());
            OpenInfoPageCommand = new DelegateCommand<TractorInfo>(async (x) => await OpenInfoPageAsync(x));
        }

        private async Task OpenInfoPageAsync(TractorInfo tractorInfo)
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                ShowLoading();

                var parametrs = new NavigationParameters();
                parametrs.Add(NavigationConstants.TractorInfo, tractorInfo);

                await NavigationService.NavigateAsync(nameof(TractorDetailsPage), parametrs);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                HideLoading();
                IsBusy = false;
            }
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if(!Items.Any())
            {
                await ExecuteRefreshAsync();
            }
        }

        private async Task ExecuteRefreshAsync()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                ShowLoading();

                await Task.Delay(2000);

                var items = new List<TractorInfo>
                {
                    new TractorInfo
                    {
                        TractorNumber = 1,
                        IsAtGarage = true,
                        CurrentFuelLevel = 0.50,
                        FuelInfo = new List<FuelLevelInfo>
                        {
                            new FuelLevelInfo { FuelLevel = 0.50, Time = DateTime.Now },
                            new FuelLevelInfo { FuelLevel = 0.50, Time = DateTime.Now.AddHours(-1) },
                            new FuelLevelInfo { FuelLevel = 0.50, Time = DateTime.Now.AddHours(-2) },
                            new FuelLevelInfo { FuelLevel = 0.60, Time = DateTime.Now.AddHours(-3) },
                            new FuelLevelInfo { FuelLevel = 0.70, Time = DateTime.Now.AddHours(-4) },
                        }
                    },
                    new TractorInfo
                    {
                        TractorNumber = 2,
                        IsAtGarage = false,
                        CurrentFuelLevel = 1,
                        FuelInfo = new List<FuelLevelInfo>
                        {
                            new FuelLevelInfo { FuelLevel = 1, Time = DateTime.Now },
                            new FuelLevelInfo { FuelLevel = 0.15, Time = DateTime.Now.AddHours(-1) },
                            new FuelLevelInfo { FuelLevel = 0.30, Time = DateTime.Now.AddHours(-2) },
                            new FuelLevelInfo { FuelLevel = 0.45, Time = DateTime.Now.AddHours(-3) },
                            new FuelLevelInfo { FuelLevel = 0.40, Time = DateTime.Now.AddHours(-4) },
                        }
                    },
                    new TractorInfo
                    {
                        TractorNumber = 3,
                        IsAtGarage = true,
                        CurrentFuelLevel = 0.10,
                        FuelInfo = new List<FuelLevelInfo>
                        {
                            new FuelLevelInfo { FuelLevel = 0.10, Time = DateTime.Now },
                            new FuelLevelInfo { FuelLevel = 0.10, Time = DateTime.Now.AddHours(-1) },
                            new FuelLevelInfo { FuelLevel = 0.15, Time = DateTime.Now.AddHours(-2) },
                            new FuelLevelInfo { FuelLevel = 0.70, Time = DateTime.Now.AddHours(-3) },
                            new FuelLevelInfo { FuelLevel = 0.70, Time = DateTime.Now.AddHours(-4) },
                        }
                    },
                    new TractorInfo
                    {
                        TractorNumber = 4,
                        IsAtGarage = false,
                        CurrentFuelLevel = 0.50,
                        FuelInfo = new List<FuelLevelInfo>
                        {
                            new FuelLevelInfo { FuelLevel = 0.50, Time = DateTime.Now },
                            new FuelLevelInfo { FuelLevel = 0.55, Time = DateTime.Now.AddHours(-1) },
                            new FuelLevelInfo { FuelLevel = 0.60, Time = DateTime.Now.AddHours(-2) },
                            new FuelLevelInfo { FuelLevel = 0.60, Time = DateTime.Now.AddHours(-3) },
                            new FuelLevelInfo { FuelLevel = 0.70, Time = DateTime.Now.AddHours(-4) },
                        }
                    },
                    new TractorInfo
                    {
                        TractorNumber = 5,
                        IsAtGarage = false,
                        CurrentFuelLevel = 0.50,
                        FuelInfo = new List<FuelLevelInfo>
                        {
                            new FuelLevelInfo { FuelLevel = 0.50, Time = DateTime.Now },
                            new FuelLevelInfo { FuelLevel = 0.55, Time = DateTime.Now.AddHours(-1) },
                            new FuelLevelInfo { FuelLevel = 0.60, Time = DateTime.Now.AddHours(-2) },
                            new FuelLevelInfo { FuelLevel = 0.60, Time = DateTime.Now.AddHours(-3) },
                            new FuelLevelInfo { FuelLevel = 0.70, Time = DateTime.Now.AddHours(-4) },
                        }
                    }
                };

                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                HideLoading();
                IsBusy = false;
            }
        }
    }
}
