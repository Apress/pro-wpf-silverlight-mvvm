using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMoney.Model
{
    public interface IPerson 
    {
        Money NetWorth
        {
            get;
        }

        IEnumerable<IAccount> Accounts
        {
            get;
        }

        void AddAccount(IAccount account);
    }
}
