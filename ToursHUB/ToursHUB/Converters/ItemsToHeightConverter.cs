using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Globalization;

namespace ToursHUB.Converters
{
    public class ItemsToHeightConverter : IValueConverter
    {
        private const int ItemHeight = 156;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                return System.Convert.ToInt32(value) * ItemHeight;
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
