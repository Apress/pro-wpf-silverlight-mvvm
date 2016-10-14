using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyMoney.Model;

namespace MyMoney.ViewModel
{
    public class EntryViewModel : INotifyPropertyChanged, IEditableObject
    {
        #region Constructors

        public EntryViewModel()
        {
            _entry = new Entry(EntryType.Withdrawal, 0.0M);
        }

        internal EntryViewModel(AccountViewModel accountViewModel)
        {
            _accountViewModel = accountViewModel;
            _entry = new Entry(EntryType.Withdrawal, 0.0M);
        }

        internal EntryViewModel(AccountViewModel accountViewModel, Entry entry)
        {
            _accountViewModel = accountViewModel;
            _entry = entry;
        }

        #endregion

        #region Properties

        public AccountViewModel AccountViewModel
        {
            set
            {
                if (value != null)
                {
                    _accountViewModel = value;
                }
            }
        }

        public string Description
        {
            get
            {
                return _entry.Description;
            }
            set
            {
                if (_entry.Description != value)
                {
                    _entry.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public MoneyViewModel Deposit
        {
            get 
            {
                Money deposit = Money.Undefined;
                if (_entry.EntryType == EntryType.Deposit)
                {
                    deposit = _entry.Amount;
                }
                return new MoneyViewModel(deposit);
            }
            set
            {
                if (_entry.EntryType == EntryType.Deposit)
                {
                    if (_entry.Amount != value.Money)
                    {
                        _entry.Amount = value.Money;
                    }
                }
                else
                {
                    _entry = new Entry(EntryType.Deposit, value.Money);
                    OnPropertyChanged("Withdrawal");
                }
                OnPropertyChanged("Deposit");
                OnPropertyChanged("CurrentBalance");
            }
        }

        public MoneyViewModel Withdrawal
        {
            get
            {
                Money withdrawal = Money.Undefined;
                if (_entry.EntryType == EntryType.Withdrawal)
                {
                    withdrawal = _entry.Amount;
                }
                return new MoneyViewModel(withdrawal);
            }
            set
            {
                if (_entry.EntryType == EntryType.Withdrawal)
                {
                    if (_entry.Amount != value.Money)
                    {
                        _entry.Amount = value.Money;
                    }
                }
                else
                {
                    _entry = new Entry(EntryType.Withdrawal, value.Money);
                    OnPropertyChanged("Deposit");
                }
                OnPropertyChanged("Withdrawal");
                OnPropertyChanged("CurrentBalance");
            }
        }

        public MoneyViewModel CurrentBalance
        {
            get
            {
                return _accountViewModel.BalanceAt(this);
            }
        }

        internal Entry Entry
        {
            get { return _entry; }
        }

        #endregion

        #region Methods

        internal void BalanceChanged()
        {
            OnPropertyChanged("CurrentBalance");
        }

        private void Save()
        {
            (_accountViewModel.Account as LeafAccount).AddEntry(_entry);
            _accountViewModel.EntryChanged(this);
            OnPropertyChanged("CurrentBalance");
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        void IEditableObject.BeginEdit()
        {
            if (!_isInTransaction)
            {
                _backupEntry = _entry; 
                _isInTransaction = true;
            }
        }

        void IEditableObject.CancelEdit()
        {
            if (_isInTransaction)
            {
                _entry = _backupEntry;
                _isInTransaction = false;
            }
        }

        void IEditableObject.EndEdit()
        {
            if (_isInTransaction)
            {
                _backupEntry = null;
                Save();
                _isInTransaction = false;
            }
        }

        #endregion

        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;

        private AccountViewModel _accountViewModel;
        private Entry _entry;
        private Entry _backupEntry;
        private bool _isInTransaction;

        #endregion       
    }
}
