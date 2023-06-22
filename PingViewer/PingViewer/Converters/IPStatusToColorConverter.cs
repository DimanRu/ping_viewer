using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Net.NetworkInformation;
using System.Windows.Media;

namespace PingViewer.Converters
{
    internal class IPStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (IPStatus)value switch
            {
                IPStatus.Unknown => new SolidColorBrush(Color.FromRgb(80, 80, 80)),
                IPStatus.Success => new SolidColorBrush(Color.FromRgb(0, 153, 0)),
                _ => new SolidColorBrush(Color.FromRgb(255, 64, 25))
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
