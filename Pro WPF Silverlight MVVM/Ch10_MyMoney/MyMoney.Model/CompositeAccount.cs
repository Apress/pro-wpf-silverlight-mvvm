using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMoney.Model
{
    public class CompositeAccount : IAccount
    {
        #region Constructors

        public CompositeAccount(string name)
        {
            Name = name;
            _childAccounts = new List<IAccount>();
                        
        }

        #endregion

        #region IAccount Implementation

        public string Name
        {
            get;
            private set;
        }

        public Money Balance
        {
            get 
            {
                Money balance = Money.Zero;

                foreach (IAccount account in ChildAccounts)
                {
                    balance += account.Balance;
                }

                return balance;
            }
        }

        public IEnumerable<IAccount> ChildAccounts
        {
            get { return _childAccounts; }
        }

        public IAccount Parent
        {
            get;
            set;
        }
        
        #endregion

        #region Methods

        public void AddAccount(IAccount account)
        {
            if (account.Parent != null)
            {
                throw new InvalidOperationException("Cannot add an account that has a parent without removing it first");
            }
            if (_childAccounts.Count(child => child.Name == account.Name) > 0)
            {
                throw new InvalidOperationException("Cannot add an account that has the same name as an existing sibling");
            }
            if (IsAncestor(account))
            {
                throw new InvalidOperationException("Cannot create a cyclical account hierarchy");
            }
            _childAccounts.Add(account);
            account.Parent = this;
        }

        public void RemoveAccount(IAccount account)
        {
            _childAccounts.Remove(account);
        }

        protected virtual bool IsAncestor(IAccount possibleAncestor)
        {
            bool isAncestor = false;
            IAccount ancestor = this;
            while (ancestor != null)
            {
                if (possibleAncestor == ancestor)
                {
                    isAncestor = true;
                    break;
                }
                ancestor = ancestor.Parent;
            }
            return isAncestor;
        }

        #endregion

        #region Fields

        private ICollection<IAccount> _childAccounts;

        #endregion
    }
}
