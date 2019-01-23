using SharpLizer.Configuration.Settings;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Linq;

namespace SharpLizer.Configuration.UI.MainOptions
{
    internal class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter is MainOptionsViewModel viewModel)
            {
                var defaultColors = viewModel.DefaultColors;
                var returningColor = defaultColors.FirstOrDefault(x => x.Color == (Color)value);
                return returningColor;
            }

            return new SolidColorBrush((Color)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ColorInfo)value)?.Color;
        }
    }
}
