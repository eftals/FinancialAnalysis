using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace FinanceAnalysis
{
    class CurrencyConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;
            return value.ToString() + "$";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value==null) return value;
            return Double.Parse(value.ToString().Substring(0, value.ToString().Length));
        }
    }
}
