using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AMS.Mobile.Converters
{
    public class PercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value/100;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value) * 100;
        }
    }
}
