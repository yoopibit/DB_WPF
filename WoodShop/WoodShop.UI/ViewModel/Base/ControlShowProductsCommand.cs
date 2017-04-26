using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WoodShop.UI.ViewModel.Base
{
    class ControlShowProductsCommand : ICommand
    {
        private Action<object> executeFunc;
        private Func<object, bool> canExecuteFunc;

        public ControlShowProductsCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.executeFunc = execute;
            canExecuteFunc = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecuteFunc?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            executeFunc?.Invoke(parameter);
        }
    }
}
