using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyMoney.Model;

namespace MyMoney.ViewModel.Test
{
    public class MockPerson : IPerson
    {
        public MockPerson(IPerson realPerson)
        {
            _realPerson = realPerson;
        }

        public bool NetWorthWasRequested
        {
            get;
            private set;
        }

        public Money NetWorth
        {
            get
            {
                NetWorthWasRequested = true;
                return _realPerson.NetWorth;
            }
        }

        public bool AccountsWereRequested
        {
            get;
            private set;
        }

        public IEnumerable<IAccount> Accounts
        {
            get
            {
                AccountsWereRequested = true;
                return _realPerson.Accounts;
            }
        }

        public void AddAccount(IAccount account)
        {

        }

        #region Fields

        private IPerson _realPerson;

        #endregion
    }
}
