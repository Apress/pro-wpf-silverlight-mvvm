using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMoney.Model
{
    public class Entry 
    {
        public Entry(EntryType entryType, Money amount)
        {
            EntryType = entryType;
            Amount = amount;
        }

        public string Description
        {
            get;
            set;
        }

        public EntryType EntryType
        {
            get;
            private set;
        }

        public Money Amount
        {
            get;
            set;
        }

        public Money CalculateNewBalance(Money oldBalance)
        {
            Money newBalance = Money.Undefined;
            switch (EntryType)
            {
                case EntryType.Deposit:
                    newBalance = oldBalance + Amount;
                    break;
                case EntryType.Withdrawal:
                    newBalance = oldBalance - Amount;
                    break;
            }
            return newBalance;
        }
    }
}
