using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMoney.Model
{
    public class CurrencyMismatchException : Exception
    {
        #region Constructors

        public CurrencyMismatchException()
            : base()
        {

        }

        public CurrencyMismatchException(string message)
            : base(message)
        {

        }

        public CurrencyMismatchException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        #endregion

    }
}
