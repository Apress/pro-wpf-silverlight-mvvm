using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMoney.Model
{
    public class Person : IPerson, IEnumerable, IEnumerable<IAccount>
    {
        #region Constructors

        public Person()
        {
            _accounts = new List<IAccount>();
        }

        #endregion

        #region Properties

        public IEnumerable<IAccount> Accounts
        {
            get { return _accounts; }
        }

        public Money NetWorth
        {
            get
            {
                Money netWorth = Money.Zero;

                foreach (IAccount account in Accounts)
                {
                    netWorth += account.Balance;
                }
                
                return netWorth;
            }
        }

        #endregion

        #region Methods

        public void AddAccount(IAccount account)
        {
            _accounts.Add(account);
        }

        public void RemoveAccount(IAccount account)
        {
            _accounts.Remove(account);
        }

        #region IEnumerable Implementation

        public IEnumerator GetEnumerator()
        {
            return _accounts.GetEnumerator();
        }

        IEnumerator<IAccount> IEnumerable<IAccount>.GetEnumerator()
        {
            return _accounts.GetEnumerator();
        }

        #endregion

        #endregion

        #region Fields

        private ICollection<IAccount> _accounts;

        #endregion
    }
}
