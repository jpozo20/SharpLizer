﻿using SharpLizer.Configuration.Settings;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace SharpLizer.Configuration.UI.MainOptions
{
    internal class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is MainOptionsViewModel viewModel)
            {
                var defaultColors = viewModel.DefaultColors;
                ColorInfo returningColor = defaultColors.FirstOrDefault(x => x.Color == (Color)value);
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