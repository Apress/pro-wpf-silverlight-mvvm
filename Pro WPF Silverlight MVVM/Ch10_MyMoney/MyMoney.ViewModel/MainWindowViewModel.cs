using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

using MyMoney.Model;

namespace MyMoney.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Constructors

        public MainWindowViewModel()
        {
            _person = new Person();
            _openAccounts = new ObservableCollection<AccountViewModel>();
        }

        internal MainWindowViewModel(IPerson person)
        {
            _person = person;
            _openAccounts = new ObservableCollection<AccountViewModel>();
        }

        #endregion

        #region Properties

        public MoneyViewModel NetWorth
        {
            get
            {
                return new MoneyViewModel(_person.NetWorth);
            }
        }

        public ObservableCollection<AccountViewModel> Accounts
        {
            get
            {
                if (_accounts == null)
                {
                    _accounts = new ObservableCollection<AccountViewModel>();
                    foreach (IAccount account in _person.Accounts)
                    {
                        AccountViewModel accountViewModel = new AccountViewModel(account);
                        accountViewModel.PropertyChanged += new PropertyChangedEventHandler(AccountViewModelPropertyChanged);
                        _accounts.Add(accountViewModel);
                    }
                }
                return _accounts;
            }
        }

        void AccountViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentBalance")
            {
                OnPropertyChanged("NetWorth");
            }
        }

        public ObservableCollection<AccountViewModel> OpenAccounts
        {
            get { return _openAccounts; }
        }

        public AccountViewModel SelectedAccount
        {
            get
            {
                return _selectedAccount;
            }
            set
            {
                if (_selectedAccount != value)
                {
                    _selectedAccount = value;
                    OnPropertyChanged("SelectedAccount");
                }
            }
        }

        public ICommand OpenAccountCommand
        {
            get
            {
                if (_openAccountCommand == null)
                {
                    _openAccountCommand = new RelayCommand(account => OpenAccount(account as AccountViewModel));
                }
                return _openAccountCommand;
            }
        }

        public ICommand CloseAccountCommand
        {
            get
            {
                if (_closeAccountCommand == null)
                {
                    _closeAccountCommand = new RelayCommand(account => CloseAccount(account as AccountViewModel));
                }
                return _closeAccountCommand;
            }
        }

        #endregion

        #region Methods

        public CreateAccountViewModel CreateAccountViewModel()
        {
            return new CreateAccountViewModel(this);
        }

        internal void AddAccount(IAccount account)
        {
            _person.AddAccount(account);
            AccountViewModel accountViewModel = new AccountViewModel(account);
            accountViewModel.PropertyChanged += new PropertyChangedEventHandler(AccountViewModelPropertyChanged);
            _accounts.Add(accountViewModel);
        }

        private void OpenAccount(AccountViewModel account)
        {
            if (!_openAccounts.Contains(account))
            {
                _openAccounts.Add(account);
            }
            SelectedAccount = account;
        }

        private void CloseAccount(AccountViewModel account)
        {
            _openAccounts.Remove(account);
            if (SelectedAccount == account)
            {
                SelectedAccount = _openAccounts.FirstOrDefault();
            }
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

        private IPerson _person;
        private ObservableCollection<AccountViewModel> _accounts;
        private ObservableCollection<AccountViewModel> _openAccounts;
        private AccountViewModel _selectedAccount;

        private RelayCommand _openAccountCommand;
        private RelayCommand _closeAccountCommand;

        #endregion
    }
}
