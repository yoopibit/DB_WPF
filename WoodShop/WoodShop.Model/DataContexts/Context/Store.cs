using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodShop.Model.Model;

namespace WoodShop.Model.DataContexts.Context
{
    public interface IStores
    {
        IEnumerable<Model.Store> GetAll();

        Model.Store GetStore(int id);

    }

    public class Stores : IStores
    {
        private Store_wood_productsEntities1 Context { get; set; }

        public Stores(Store_wood_productsEntities1 dbContext)
        {
            Context = dbContext;
        }

        public IEnumerable<Model.Store> GetAll()
        {
                var storesFromDB = Context.Store.ToList();

                var stores = new List<Model.Store>();

                foreach (var i in storesFromDB)
                {
                    var store = new Model.Store();
                    store.description = i.descriptions;
                    store.id = i.STORE_ID;
                    store.address = GetStoreAddress(i.ADDRESS_ID);
                    stores.Add(store);
                }

                return stores;
        }

        private Model.StoreAddress GetStoreAddress(int stroreAddressId)
        {
            var address = Context.StoreAddress.Where(x => x.ADDRESS_ID == stroreAddressId).FirstOrDefault();

            return new Model.StoreAddress()
            {
                building = address.building,
                city = address.city,
                country = address.country,
                street = address.street
            };
        }

        public Model.Store GetStore(int id)
        {
            var storeDB = Context.Store.Where(x => x.STORE_ID == id).FirstOrDefault();

            if (storeDB == null)
            {
                return null;
            }

            var store = new Model.Store();

            store.address = GetStoreAddress(storeDB.ADDRESS_ID);
            store.id = storeDB.STORE_ID;
            store.description = storeDB.descriptions;

            return store;
        }
    }
}
