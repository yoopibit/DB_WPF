using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodShop.Model.Model;

namespace WoodShop.Model.DataContexts.Context
{
    public interface IOrders
    {
        IEnumerable<Order> GetCurrentOrders();
    }

    public class Orders : IOrders
    {
        private Store_wood_productsEntities1 Context { get; set; }

        public Orders(Store_wood_productsEntities1 dbContext)
        {
            Context = dbContext;
        }

        public IEnumerable<Order> GetCurrentOrders()
        {
            var orders = Context.Order.ToList();
            return orders;

            var orderDetails = Context.OrderDetail.ToList();

            var currentStoreId = StoreWoodContext.Instace.CurrentStoreId;

            //var orders = new List<Model.Order>();

            

            //foreach (var i in orderDetails)
            //{
            //    var order = new Model.Order();

            //    var products = new List<Model.OrderDetail>();

            //    var product = StoreWoodContext.Instace.Pr

            //    for (int j = 0; j < orderDetails.Count; j++)
            //    {
            //        if (orderDetails[j].PRODUCT_ID == i.PRODUCT_ID)
            //        {

            //            products.Add(new Model.OrderDetail() {Product = orderDetails[j].PRODUCT_ID)
            //        }
            //    }

            //    order.
            //}

            throw new NotImplementedException();
        }
    }
}
