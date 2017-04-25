using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WoodShop.Model.DataContexts.Context;
using WoodShop.UI.ViewModel.Base;

namespace WoodShop.UI.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        private LoginOkCommand objOkCommand;
        private LoginRegisterCommand objRegCommand;
        private LoginRegBackCommand objRegBackCommand;

        private WindowLogin windowLogin;
        private WindowRegister windowRegister;

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
            objOkCommand = new LoginOkCommand(LoadControlWindow, StoreWoodContext.Instace.Worker.CheckWorker);
            this.PropertyChanged += LoginViewModel_PropertyChanged;

            objRegBackCommand = new LoginRegBackCommand(CloseRegLoadLogin);
            objRegCommand = new LoginRegisterCommand(CloseThisLoadRegister);
        }

        private void LoadControlWindow(object window)
        {
            var windowlogin = window as Window;

            var controlWindow = new WindowControl();
            controlWindow.Show();

            windowlogin.Close();
            
        }
        private void CloseThisLoadRegister(object obj)
        {
            
            if (windowRegister == null)
                windowRegister = new WindowRegister();

            windowRegister.Show();

            windowLogin = obj as WindowLogin;
            windowLogin.Close();

        }

        private void CloseRegLoadLogin(object obj)
        {
            var windowRegister = obj as WindowRegister;

            if (windowLogin == null)
            {
                windowLogin = new WindowLogin();
            }

            windowLogin.Show();

            windowRegister.Close();

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
        public ICommand btnRegisterClick
        {
            get
            {
                return objRegCommand;
            }
        }

        public ICommand btnRegCloseClock
        {
            get
            {
                return objRegBackCommand;
            }
        }   
    }
}
