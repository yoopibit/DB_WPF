using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WoodShop.Model.DataContexts.Context;
using WoodShop.Model.Model;
using WoodShop.UI.ViewModel.Base;

namespace WoodShop.UI.ViewModel
{
    public class SignUpViewModel : ObservableObject
    {
        private SignUpOkCommand okCommand;

        public ICommand OkCommand
        {
            get
            {
                return okCommand;
            }
        }

        public SignUpViewModel()
        {
            okCommand = new SignUpOkCommand(AddWorker, CanAdd);
        }

        public void AddWorker(object _window)
        {
            try
            {
                var window = _window as WindowRegister;
                var pos = window.comboBoxPosition.SelectedValue as Position;
                var manager = window.comboBoxManager.SelectedValue as WoodShop.Model.Model.Worker;

                StoreWoodContext.Instace.Worker.AddWorker(window.textBoxName.Text, window.textBoxSurname.Text, pos.ID, manager.Id);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool CanAdd(object _window)
        {
            var window = _window as WindowRegister;

            return StoreWoodContext.Instace.Worker.CheckWorker(window.textBoxName.Text, window.textBoxSurname.Text);
        }

        public IEnumerable<Store> AllStores
        {
            get
            {
                var data =  StoreWoodContext.Instace.Store.GetAll();
                return data;
            }
        }

        public IEnumerable<Position> AllPositions
        {
            get
            {
                return StoreWoodContext.Instace.Position.GetAll();
            }
        }

        public IEnumerable<WoodShop.Model.Model.Worker> GetAllManagers
        {
            get
            {
                return StoreWoodContext.Instace.Worker.GetAllManagers();
                okCommand.RaiseCanExecuteChanged();
            }
        }

        private Store selectedStore;

        public Store SelecteStore
        {
            get
            {
                return selectedStore;
            }
            set
            {
                selectedStore = value;
                StoreWoodContext.Instace.CurrentStoreId = selectedStore.id;
                OnPropetyChange("GetAllManagers");
            }
        }
    }
}
