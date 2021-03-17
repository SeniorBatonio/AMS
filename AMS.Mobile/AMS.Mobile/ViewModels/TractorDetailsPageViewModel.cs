using AMS.Mobile.Constants;
using AMS.Mobile.Models;
using Microcharts;
using Prism.Navigation;
using SkiaSharp;
using System;
using System.Linq;

namespace AMS.Mobile.ViewModels
{
    public class TractorDetailsPageViewModel : ViewModelBase
    {
        private TractorInfo tractorInfo;
        public TractorInfo TractorInfo
        {
            get { return tractorInfo; }
            set { SetProperty(ref tractorInfo, value); }
        }

        private Chart chart;
        public Chart Chart
        {
            get { return chart; }
            set { SetProperty(ref chart, value); }
        }

        public TractorDetailsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Chart = new LineChart() 
            { 
                ValueLabelOrientation = Orientation.Horizontal,
                LabelOrientation = Orientation.Vertical,
                LabelTextSize = 50,
                PointSize = 20,
                LineMode = LineMode.Straight,
                LineSize = 5,
                Margin = 30
            };
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            TractorInfo = parameters.GetValue<TractorInfo>(NavigationConstants.TractorInfo);
            Chart.Entries = TractorInfo.FuelInfo
                .OrderBy(i => i.Time)
                .Select(i => new ChartEntry(Convert.ToSingle(i.FuelLevel))
                {
                    Label = i.Time.ToString("HH:mm:ss"),
                    ValueLabel = i.FuelLevel.ToString(),
                    Color = SKColor.Parse("#76E25B")
                });
        }
    }
}
