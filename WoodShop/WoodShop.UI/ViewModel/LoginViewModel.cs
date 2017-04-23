using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WoodShop.Model.DataContexts.Context;
using WoodShop.UI.ViewModel.Base;

namespace WoodShop.UI.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        private LoginOkCommand objOkCommand;

        public string Name
        {
            get { return objOkCommand.Name; }
            set {
                    objOkCommand.Name = value;
                    OnPropetyChange("Name");
                }
        }
        public string SecondName
        {
            get { return objOkCommand.Surname; }
            set
            {
                objOkCommand.Surname = value;
                OnPropetyChange("SecondName");
            }
        }

        public LoginViewModel()
        {
            
            // need to close current windows and load new
            objOkCommand = new LoginOkCommand(null, StoreWoodContext.Instace.Worker.CheckWorker);
            this.PropertyChanged += LoginViewModel_PropertyChanged;
        }

        private void LoginViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            objOkCommand.CanExecute(sender);
        }

        public ICommand btnOkClick
        {
            get
            {
                return objOkCommand;
            }
        } 
    }

}
