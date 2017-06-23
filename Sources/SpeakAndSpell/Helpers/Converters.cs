using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Controls;
using System.Globalization;

namespace SpeakAndSpell.Helpers
{
    public class SelectedItemToItemsSource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            return new List<object>() { value };
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    //<Window.Resources>
    //<local:StringToNullableDecimalConverter x:Key="nullDecimalConv"/>
    //</Window.Resources>
    //<TextBox Text = "{Binding Price, Converter={StaticResource nullDecimalConv}}" />
    public class StringToNullableDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal? d = (decimal?)value;
            if (d.HasValue)
                return d.Value.ToString(culture);
            else
                return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = (string)value;
            if (String.IsNullOrEmpty(s))
                return null;
            else
                return (decimal?)decimal.Parse(s, culture);
        }
    }

    //public class DoubleConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType,
    //        object parameter, CultureInfo culture)
    //    {
    //        return (double)value;
    //    }
    //
    //    public object ConvertBack(object value, Type targetType,
    //        object parameter, CultureInfo culture)
    //    {
    //        var doubleValue = System.Convert.ToDouble(value);
    //        return (doubleValue == 0 ? null : doubleValue);
    //    }
    //}

    public class StringEmptyConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.IsNullOrEmpty((string)value) ? parameter : value;
        }

        public object ConvertBack(
              object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

    }

}
