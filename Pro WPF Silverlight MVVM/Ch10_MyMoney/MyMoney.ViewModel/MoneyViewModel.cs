using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

using MyMoney.Model;

namespace MyMoney.ViewModel
{
    public class MoneyViewModel
    {
        #region Constructors

        public MoneyViewModel()
        {
            
        }

        internal MoneyViewModel(Money money)
        {
            Money = money;
        }
       
        #endregion

        #region Properties

        public string DisplayValue
        {
            get 
            {
                string displayValue = null;
                if (Money != Money.Undefined)
                {
                    displayValue = Money.Amount.ToString("C", Money.CultureInfo);
                }
                return displayValue;
            }
        }

        internal Money Money
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return DisplayValue;
        }

        #endregion
    }
}
