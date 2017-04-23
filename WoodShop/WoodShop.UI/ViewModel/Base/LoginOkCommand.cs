using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WoodShop.UI.ViewModel.Base
{
    class LoginOkCommand : ICommand
    {
        private Action<object> executeFunc;
        private Func<string, string, bool> canExecuteFunc;
        public string Name;
        public string Surname;

        public LoginOkCommand(Action<object> execute, Func<string, string, bool> canExecute = null)
        {
            this.executeFunc = execute;
            canExecuteFunc = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (canExecuteFunc?.Invoke(Name, Surname) ?? true)
            {
                executeFunc?.Invoke(parameter);
            }
        }
    }
}
