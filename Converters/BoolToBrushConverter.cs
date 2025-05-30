using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace CursovaRobota.Helpers
{
    public class BoolToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = value is bool vb && vb;
            return b
               ? (Brush)Application.Current.Resources["PrimaryBrush"]
               : (Brush)Application.Current.Resources["OnSurfaceVariantBrush"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
