// <copyright file="InvertBoolToVisibilityConverter.cs" company="Matthew Law">
// Copyright (c) Matthew Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Utilities
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class InvertBoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool r && r ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
