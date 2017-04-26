using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodShop.Model.Model;

namespace WoodShop.Model.DataContexts.Context
{
    public interface IProducts
    {
        Model.Product GetByIdFromStore(int productId);

        IEnumerable<Model.Product> GetProductFromCurrentShop();
    }
    class Products : IProducts
    {
        private Store_wood_productsEntities1 Context { get; set; }

        public IEnumerable<Model.Product> GetProductFromCurrentShop()
        {
            var res = new List<Model.Product>();

            var products = Context.ProductStore.Where( x => x.STORE_ID == StoreWoodContext.Instace.CurrentStoreId).ToList();

            foreach(var i in products)
            {
                res.Add(GetByIdFromStore(i.PRODUCT_ID));
            }

            return res;
        }

        public Model.Product GetByIdFromStore(int id)
        {
            var productStoreDB = Context.ProductStore.Where(x => x.PRODUCT_ID == id && x.STORE_ID == StoreWoodContext.Instace.CurrentStoreId).First();

            if (productStoreDB == null)
            {
                throw new Exception("Not found product by id = " + id);
            }

            var productDB = Context.Product.Where(x => x.PRODUCT_INFO_ID == productStoreDB.PRODUCT_INFO_ID).First();

            if (productDB == null)
            {
                throw new Exception("Not found product details by id = " + productStoreDB.PRODUCT_INFO_ID);
            }

            var productTypeDB = Context.ProductType.Where(x => x.PRODUCT_TYPE_ID == productStoreDB.PRODUCT_TYPE_ID).First();

            if (productTypeDB == null)
            {
                throw new Exception("Not found product type id = " + productStoreDB.PRODUCT_TYPE_ID);
            }

            Model.Product product = new Model.Product()
            {
                Date = productStoreDB.date,
                Name = productDB.name,
                Number = productStoreDB.number,
                Price = productStoreDB.price,
                Type = productTypeDB.type
            };

            return product;
        }

        public Products(Store_wood_productsEntities1 dbContext)
        {
            Context = dbContext;
        }
    }
}
