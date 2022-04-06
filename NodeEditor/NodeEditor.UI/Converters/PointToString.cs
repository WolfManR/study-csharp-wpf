﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NodeEditor.UI.Converters;

public class PointToString : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var point = (Point)value;
        return $"{point.X}, {point.Y}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}