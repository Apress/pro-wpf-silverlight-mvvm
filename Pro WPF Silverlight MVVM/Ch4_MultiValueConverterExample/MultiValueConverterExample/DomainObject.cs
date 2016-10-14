using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Globalization;

namespace MultiValueConverterExample
{
    public class DomainObject
    {
        public Color ConvertQuarterAndBalanceToColor(string month, decimal balance)
        {
            int quarter = ConvertMonthNameToQuarter(month);
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

        private int ConvertMonthNameToQuarter(string month)
        {
            DateTime monthDateTime = DateTime.MinValue;
            DateTime.TryParseExact(month, "MMMM", CultureInfo.CurrentCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal, out monthDateTime);
            return (monthDateTime.Month + 2) / 3;
        }
    }
}
