using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using MyMoney.Model;

namespace MyMoney.ViewModel
{
    public class AccountViewModel : INotifyPropertyChanged
    {
        #region Constructors

        internal AccountViewModel(IAccount account)
        {
            _account = account;
        }

        #endregion

        #region Properties

        public string Name
        {
            get { return _account.Name; }
        }

        public bool HasChildren
        {
            get { return _account is CompositeAccount; }
        }

        public ObservableCollection<AccountViewModel> ChildAccounts
        {
            get
            {
                if (_childAccounts == null)
                {
                    _childAccounts = new ObservableCollection<AccountViewModel>();
                    if (HasChildren)
                    {
                        foreach (IAccount account in (_account as CompositeAccount).ChildAccounts)
                        {
                            _childAccounts.Add(new AccountViewModel(account));
                        }
                    }
                }
                return _childAccounts;
            }
        }

        public BindingList<EntryViewModel> Entries
        {
            get
            {
                if (_entries == null)
                {
                    _entries = new BindingList<EntryViewModel>();
                    _entries.AddingNew += new AddingNewEventHandler(EntriesAddingNew);
                    if (!HasChildren)
                    {
                        foreach (Entry entry in (_account as LeafAccount).Entries)
                        {
                            EntryViewModel newEntry = new EntryViewModel(this, entry);
                            _entries.Add(newEntry);
                        }
                    }
                }
                return _entries;
            }
        }

        private void EntriesAddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new EntryViewModel(this);
        }

        public MoneyViewModel CurrentBalance
        {
            get
            {
                return new MoneyViewModel(_account.Balance);
            }
        }

        internal IAccount Account
        {
            get
            {
                return _account;
            }
        }

        #endregion

        #region Methods

        public MoneyViewModel BalanceAt(EntryViewModel entryViewModel)
        {
            return new MoneyViewModel((_account as LeafAccount).BalanceAt(entryViewModel.Entry));
        }

        internal void EntryChanged(EntryViewModel entryViewModel)
        {
            foreach (EntryViewModel currentEntryViewModel in _entries)
            {
                currentEntryViewModel.BalanceChanged();
            }
            OnPropertyChanged("CurrentBalance");
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion

        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<AccountViewModel> _childAccounts;
        private BindingList<EntryViewModel> _entries;
        private IAccount _account;

        #endregion
    }
}
