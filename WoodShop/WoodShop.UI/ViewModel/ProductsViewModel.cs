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
    public class ProductsViewModel : ObservableObject
    {
        public IEnumerable<WoodShop.Model.Model.Product> GetProducts
        {
            get
            {
                return StoreWoodContext.Instace.Products.GetProductFromCurrentShop();
            }
        }
    }
}
