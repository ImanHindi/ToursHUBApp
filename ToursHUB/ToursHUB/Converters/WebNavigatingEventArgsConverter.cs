using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Globalization;

namespace ToursHUB.Converters
{

    public class WebNavigatingEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as WebNavigatingEventArgs;
            if (eventArgs == null)
                throw new ArgumentException("Expected WebNavigatingEventArgs as value", "value");

            return eventArgs.Url;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
