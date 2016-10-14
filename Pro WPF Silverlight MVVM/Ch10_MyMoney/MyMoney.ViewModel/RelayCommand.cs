using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MyMoney.ViewModel
{
    public class RelayCommand : ICommand
    {
        #region Constructors

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {

        }

        #endregion

        #region ICommand Implementation

        public bool CanExecute(object parameter)
        {
            bool canExecute = true;
            if (_canExecute != null)
            {
                canExecute = _canExecute(parameter);
            }
            return canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion

        #region Fields

        private Action<object> _execute;
        private Predicate<object> _canExecute;

        #endregion
    }
}
