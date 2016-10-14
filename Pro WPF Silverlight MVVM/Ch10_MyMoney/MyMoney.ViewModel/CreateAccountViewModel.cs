using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using MyMoney.Model;

namespace MyMoney.ViewModel
{
    public class CreateAccountViewModel
    {
        internal CreateAccountViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public string Name
        {
            get;
            set;
        }

        public string OpeningBalance
        {
            get;
            set;
        }

        private RelayCommand _createAccountCommand;
        public ICommand CreateAccountCommand
        {
            get
            {
                if (_createAccountCommand == null)
                {
                    _createAccountCommand = new RelayCommand(param => CreateAccount(), param => CanCreateAccount());
                }
                return _createAccountCommand;
            }
        }

        public void CreateAccount()
        {
            IAccount account = null;
            if(string.IsNullOrWhiteSpace(OpeningBalance))
            {
                account = new LeafAccount(Name);
            }
            else
            {
                decimal openingBalance= decimal.Parse(OpeningBalance);
                account = new LeafAccount(Name, new Money(openingBalance));
            }
            _mainWindowViewModel.AddAccount(account);
        }

        public bool CanCreateAccount()
        {
            bool hasValidName = !string.IsNullOrWhiteSpace(Name);
            decimal openingBalance;
            bool hasValidOpeningBalance = string.IsNullOrWhiteSpace(OpeningBalance) || decimal.TryParse(OpeningBalance, out openingBalance);

            return hasValidName && hasValidOpeningBalance;
        }

        private MainWindowViewModel _mainWindowViewModel;
    }
}
