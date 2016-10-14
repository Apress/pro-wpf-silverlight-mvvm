using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace EventCommandExample
{
    public class LogInViewModel
    {
        public LogInViewModel()
        {
            //_logInModel = new LogInModel();
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        private RelayCommand _logInCommand;
        public ICommand LogInCommand
        {
            get
            {
                if (_logInCommand == null)
                {
                    _logInCommand = new RelayCommand(param => this.AttemptLogIn(), param => this.CanAttemptLogIn());
                }
                return _logInCommand;
            }
        }

        private void AttemptLogIn()
        {
            //_logInModel.LogIn(UserName, Password);
        }

        private bool CanAttemptLogIn()
        {
            return !String.IsNullOrWhiteSpace(UserName) && !String.IsNullOrWhiteSpace(Password);
        }
    }
}
