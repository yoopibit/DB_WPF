using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodShop.Model;
using WoodShop.Model.DataContexts.Context;
using WoodShop.UI.ViewModel.Base;

namespace WoodShop.UI.ViewModel
{
    public class OrdersViewModel : ObservableObject
    {
        public IEnumerable<Order> Orders
        {
            get
            {
                return StoreWoodContext.Instace.Orders.GetCurrentOrders();
            }
        }
    }
}
