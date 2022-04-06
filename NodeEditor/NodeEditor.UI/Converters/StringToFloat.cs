using System;
using System.Globalization;
using System.Windows.Data;

namespace NodeEditor.UI.Converters;

public class StringToFloat : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null) return 0f;
        if (parameter != null && (string)parameter == "double")
        {
            return double.Parse((string)value);
        }
        return float.Parse((string)value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value.ToString();
    }
}