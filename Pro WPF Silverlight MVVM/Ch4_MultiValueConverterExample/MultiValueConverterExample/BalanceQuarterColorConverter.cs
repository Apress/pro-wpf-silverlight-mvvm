using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace MultiValueConverterExample
{
    public class BalanceQuarterColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object convertedValue = null;
            if (values.Count() == 2)
            {
                string month = null;
                decimal balance = decimal.MinValue;
                foreach (object value in values)
                {
                    if (value is string)
                    {
                        month = value as string;
                    }
                    else if (value is decimal)
                    {
                        balance = (decimal)value;
                    }
                }

                DateTime monthDateTime = DateTime.MinValue;
                if (DateTime.TryParseExact(month, "MMMM", culture.DateTimeFormat, System.Globalization.DateTimeStyles.AssumeUniversal, out monthDateTime))
                {
                    int quarter = (monthDateTime.Month + 2) / 3;
                    convertedValue = ConvertQuarterAndBalanceToColor(quarter, balance);
                }
            }
            return convertedValue;
        }

        private Color ConvertQuarterAndBalanceToColor(int quarter, decimal balance)
        {
            Color outputColor = Colors.Magenta;
            if (balance == decimal.Zero)
            {
                outputColor = Colors.Black;
            }
            else if (balance > decimal.Zero)
            {
                outputColor = Colors.Green;
            }
            else
            {
                switch (quarter)
                {
                    case 1:
                        outputColor = Colors.Yellow;
                        break;
                    case 2:
                        outputColor = Colors.DarkOrange;
                        break;
                    case 3:
                        outputColor = Colors.OrangeRed;
                        break;
                    case 4:
                        outputColor = Colors.Red;
                        break;
                    default:
                        outputColor = Colors.Magenta;
                        break;
                }
            }
            return outputColor;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
