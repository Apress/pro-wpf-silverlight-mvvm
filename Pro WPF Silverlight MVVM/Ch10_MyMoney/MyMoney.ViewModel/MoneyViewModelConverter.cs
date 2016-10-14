using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

using MyMoney.Model;

namespace MyMoney.ViewModel
{
    public class MoneyViewModelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;   
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MoneyViewModel moneyViewModel = null;
            if (value is string)
            {
                string valueString = value as string;

                decimal decimalValue = decimal.Zero;
                if (decimal.TryParse(valueString, out decimalValue))
                {
                    Money money = new Money(decimalValue);
                    moneyViewModel = new MoneyViewModel(money);
                }
            }
            return moneyViewModel;
        }
    }
}
