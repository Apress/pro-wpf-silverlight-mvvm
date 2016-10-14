using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace MyMoney.Model
{
    public struct Money
    {
        #region Constructors

        public Money(decimal amount)
            : this(amount, CultureInfo.CurrentCulture) 
        {

        }

        public Money(decimal amount, CultureInfo cultureInfo)
            : this()
        {
            _cultureInfo = cultureInfo;
            Amount = amount;
        }

        #endregion

        #region Properties

        public decimal Amount
        {
            get;
            private set;
        }

        public string CurrencyName
        {
            get
            {
                RegionInfo regionInfo = new RegionInfo(_cultureInfo.LCID);
                return regionInfo.CurrencySymbol;
            }
        }

        public string CurrencySymbol
        {
            get
            {
                RegionInfo regionInfo = new RegionInfo(_cultureInfo.LCID);
                return regionInfo.CurrencySymbol;
            }
        }

        public CultureInfo CultureInfo
        {
            get
            {
                return _cultureInfo;
            }
        }

        #endregion

        #region Methods

        #region Money Arithmetic

        public static Money operator +(Money lhs, Money rhs)
        {
            Money result = Money.Undefined;
            if (lhs._cultureInfo == rhs._cultureInfo && lhs != Money.Undefined && rhs != Money.Undefined)
            {
                result = new Money(lhs.Amount + rhs.Amount);
            }
            return result;
        }

        public static Money operator -(Money lhs, Money rhs)
        {
            Money result = Money.Undefined;
            if (lhs._cultureInfo == rhs._cultureInfo && lhs != Money.Undefined && rhs != Money.Undefined)
            {
                result = new Money(lhs.Amount - rhs.Amount);
            }
            return result;
        }

        #endregion

        #region Money Comparison

        public static bool operator ==(Money lhs, Money rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Money lhs, Money rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static bool operator >(Money lhs, Money rhs)
        {
            if(lhs._cultureInfo != rhs._cultureInfo)
                throw new CurrencyMismatchException();
            return lhs.Amount > rhs.Amount;
        }

        public static bool operator <(Money lhs, Money rhs)
        {
            if(lhs._cultureInfo != rhs._cultureInfo)
                throw new CurrencyMismatchException();
            return lhs.Amount < rhs.Amount;
        }

        public static bool operator >=(Money lhs, Money rhs)
        {
            if(lhs._cultureInfo != rhs._cultureInfo)
                throw new CurrencyMismatchException();
            return lhs.Amount >= rhs.Amount;
        }

        public static bool operator <=(Money lhs, Money rhs)
        {
            if(lhs._cultureInfo != rhs._cultureInfo)
                throw new CurrencyMismatchException();
            return lhs.Amount >= rhs.Amount;
        }

        #endregion

        #region Decimal Arithmetic

        public static Money operator +(Money money, decimal value)
        {
            return money.Amount + value;
        }
        
        public static Money operator -(Money money, decimal value)
        {
            return money.Amount - value;
        }

        public static Money operator *(Money money, int value)
        {
            return money.Amount * value;
        }

        public static Money operator /(Money money, int value)
        {
            return money.Amount / value;
        }

        #endregion

        #region Decimal Comparison

        public static bool operator ==(Money money, decimal amount)
        {
            return money.Amount == amount;
        }

        public static bool operator !=(Money money, decimal amount)
        {
            return money.Amount != amount;
        }

        public static bool operator >(Money money, decimal amount)
        {
            return money.Amount > amount;
        }

        public static bool operator <(Money money, decimal amount)
        {
            return money.Amount < amount;
        }

        public static bool operator >=(Money money, decimal amount)
        {
            return money.Amount >= amount;
        }

        public static bool operator <=(Money money, decimal amount)
        {
            return money.Amount <= amount;
        }

        public static implicit operator Money(decimal amount)
        {
            return new Money(amount);
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Money other = (Money)obj;
            return _cultureInfo == other._cultureInfo && Amount == other.Amount;
        }

        public override int GetHashCode()
        {
 	         return Amount.GetHashCode() ^ _cultureInfo.GetHashCode();
        }

        #endregion

        #region Fields

        private CultureInfo _cultureInfo;

        public static readonly Money Undefined = new Money(-1, null);
        public static readonly Money Zero = new Money(0);

        #endregion
    }


}
