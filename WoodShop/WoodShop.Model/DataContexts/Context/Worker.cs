using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodShop.Model.DataContexts.Context
{
    public interface IWorkerDbContext
    {
        bool CheckWorker(string name, string surname);
    }

    public class Worker : IWorkerDbContext
    {
        private Store_wood_productsEntities1 Context { get; set;}

        public Worker(Store_wood_productsEntities1 dbContext)
        {
            Context = dbContext;
        }

        public bool CheckWorker(string name, string surname)
        {
            if (name == null || surname == null)
            {
                return false;
            }
            try
            {
                var worker = Context.Worker.Where(w => (w.first_name == name && w.second_name == surname))
                    .FirstOrDefault();
            if (worker == null)
            {
                StoreWoodContext.Instace.CurrentStoreId = -1;
                return false;
            }
                var inst = StoreWoodContext.Instace;
                inst.CurrentStoreId = worker.STORE_ID;

            return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
