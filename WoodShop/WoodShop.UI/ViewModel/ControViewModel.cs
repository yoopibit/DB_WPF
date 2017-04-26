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
    public class ControViewModel : ObservableObject
    {
        private ControlShowOrdersCommand objShowOrders;
        private ControlShowProductsCommand objShowProduct;

        public ControViewModel()
        {
            objShowOrders = new ControlShowOrdersCommand(ShowOrders);
            objShowProduct = new ControlShowProductsCommand(ShowProducts);
        }

        void ShowOrders(object obj)
        {
            var winOrders = new WindowOrders();

            winOrders.Show();
        }

        void ShowProducts(object obj)
        {
            var winProducts = new WindowProducts();

            winProducts.Show();
        }

        public string Name
        {
            get
            {
                return StoreWoodContext.Instace.Worker.GetCurrentWorker().Name;
            }
        }
        public string Surname
        {
            get
            {
                return StoreWoodContext.Instace.Worker.GetCurrentWorker().Surname;
            }
        }

        public string StoreAddress
        {
            get
            {

                var address = StoreWoodContext.Instace.Worker.GetCurrentWorker().Store.address;

                return address.country + ", " + address.city + ", " + address.street + ", " + address.building;
            }
        }
        public string StoreDescription
        {
            get
            {
                var store = StoreWoodContext.Instace.Worker.GetCurrentWorker().Store;
                var desc = store.description == null ? "" : store.description;

                return desc;
            }
        }

        public ICommand ShowWinOrders
        {
            get
            {
                return objShowOrders;
            }
        }

        public ICommand ShowWinProducts
        {
            get
            {
                return objShowProduct;
            }
        }

    }
}
