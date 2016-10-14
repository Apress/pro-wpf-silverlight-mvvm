using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMoney.Model
{
    public class LeafAccount : IAccount
    {
        #region Constructors

        public LeafAccount(string name)
            : this(name, Money.Zero)
        {
            
        }

        public LeafAccount(string name, Money openingBalance)
        {
            Name = name;
            OpeningBalance = openingBalance;
            _entries = new List<Entry>();
        }

        #endregion

        #region IAccount Implementation

        public string Name
        {
            get;
            private set;
        }

        public Money OpeningBalance
        {
            get;
            private set;
        }

        public IEnumerable<Entry> Entries
        {
            get { return _entries; }
        }

        public Money Balance
        {
            get 
            {
                Money balance = OpeningBalance;
                foreach(Entry entry in Entries)
                {
                    balance = entry.CalculateNewBalance(balance);
                }
                return balance;
            }
        }

        public IAccount Parent
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public void AddEntry(Entry entry)
        {
            if (!_entries.Contains(entry))
            {
                _entries.Add(entry);
            }
        }

        public Money BalanceAt(Entry entry)
        {
            Money balanceAt = OpeningBalance;
            foreach (Entry currentEntry in _entries)
            {
                balanceAt = currentEntry.CalculateNewBalance(balanceAt);
                if (currentEntry == entry)
                {
                    break;
                }
            }
            return balanceAt;
        }

        #endregion

        #region Fields

        private ICollection<Entry> _entries;

        #endregion
    }
}
