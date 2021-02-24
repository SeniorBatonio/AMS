using AMS.Mobile.Extensions;
using AMS.Mobile.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            OpenInfoPageCommand = new DelegateCommand(async () => await OpenInfoPageAsync());
        }

        private async Task OpenInfoPageAsync()
        {

        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            await ExecuteRefreshAsync();
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
                        FuelInfo = new List<FuelLevelInfo>
                        {
                            new FuelLevelInfo { FuelLevel = 50, Time = DateTime.Now },
                            new FuelLevelInfo { FuelLevel = 55, Time = DateTime.Now.AddHours(-1) },
                            new FuelLevelInfo { FuelLevel = 60, Time = DateTime.Now.AddHours(-2) },
                            new FuelLevelInfo { FuelLevel = 60, Time = DateTime.Now.AddHours(-3) },
                            new FuelLevelInfo { FuelLevel = 70, Time = DateTime.Now.AddHours(-4) },
                        }
                    },
                    new TractorInfo
                    {
                        TractorNumber = 2,
                        IsAtGarage = false,
                        FuelInfo = new List<FuelLevelInfo>
                        {
                            new FuelLevelInfo { FuelLevel = 50, Time = DateTime.Now },
                            new FuelLevelInfo { FuelLevel = 55, Time = DateTime.Now.AddHours(-1) },
                            new FuelLevelInfo { FuelLevel = 60, Time = DateTime.Now.AddHours(-2) },
                            new FuelLevelInfo { FuelLevel = 60, Time = DateTime.Now.AddHours(-3) },
                            new FuelLevelInfo { FuelLevel = 70, Time = DateTime.Now.AddHours(-4) },
                        }
                    },
                    new TractorInfo
                    {
                        TractorNumber = 3,
                        IsAtGarage = true,
                        FuelInfo = new List<FuelLevelInfo>
                        {
                            new FuelLevelInfo { FuelLevel = 50, Time = DateTime.Now },
                            new FuelLevelInfo { FuelLevel = 55, Time = DateTime.Now.AddHours(-1) },
                            new FuelLevelInfo { FuelLevel = 60, Time = DateTime.Now.AddHours(-2) },
                            new FuelLevelInfo { FuelLevel = 60, Time = DateTime.Now.AddHours(-3) },
                            new FuelLevelInfo { FuelLevel = 70, Time = DateTime.Now.AddHours(-4) },
                        }
                    },
                    new TractorInfo
                    {
                        TractorNumber = 4,
                        IsAtGarage = false,
                        FuelInfo = new List<FuelLevelInfo>
                        {
                            new FuelLevelInfo { FuelLevel = 50, Time = DateTime.Now },
                            new FuelLevelInfo { FuelLevel = 55, Time = DateTime.Now.AddHours(-1) },
                            new FuelLevelInfo { FuelLevel = 60, Time = DateTime.Now.AddHours(-2) },
                            new FuelLevelInfo { FuelLevel = 60, Time = DateTime.Now.AddHours(-3) },
                            new FuelLevelInfo { FuelLevel = 70, Time = DateTime.Now.AddHours(-4) },
                        }
                    },
                    new TractorInfo
                    {
                        TractorNumber = 5,
                        IsAtGarage = false,
                        FuelInfo = new List<FuelLevelInfo>
                        {
                            new FuelLevelInfo { FuelLevel = 50, Time = DateTime.Now },
                            new FuelLevelInfo { FuelLevel = 55, Time = DateTime.Now.AddHours(-1) },
                            new FuelLevelInfo { FuelLevel = 60, Time = DateTime.Now.AddHours(-2) },
                            new FuelLevelInfo { FuelLevel = 60, Time = DateTime.Now.AddHours(-3) },
                            new FuelLevelInfo { FuelLevel = 70, Time = DateTime.Now.AddHours(-4) },
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
