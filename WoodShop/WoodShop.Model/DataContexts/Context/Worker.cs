using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodShop.Model.Model;

namespace WoodShop.Model.DataContexts.Context
{
    public interface IWorkerDbContext
    {
        bool CheckWorker(string name, string surname);

        void AddWorker(string name, string surname, int posId, int managerId);

        IEnumerable<Model.Worker> GetAllManagers();
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


        private bool IsWorkerExist(string Name, string Surname)
        {
            var worker = Context.Worker.Where(x => x.first_name == Name && x.second_name == Surname).ToList();

            if (worker.Count == 0)
                return false;

            return true;
        }

        public void AddWorker(string name, string surname, int posId, int managerId)
        {
            if (posId == 2 && managerId != -1)
                throw new Exception("Please do not choose manager");

            if (posId != 2 && managerId == -1)
                throw new Exception("Please choose manager");

            if (IsWorkerExist(name, surname))
                throw new Exception("Worker exist in the current store");

            var worker = new WoodShop.Model.Worker();
            worker.first_name = name;
            worker.second_name = surname;
            worker.STORE_ID = StoreWoodContext.Instace.CurrentStoreId;
            worker.WORKER_POSITION_ID = posId;
            worker.MANAGER_ID = managerId;
            worker.rating = 0;
            worker.phone_number = "063-14-212-40";
            
            Context.Worker.Add(worker);
            Context.SaveChanges();
        }

        public IEnumerable<Model.Worker> GetAllManagers()
        {
            int storeId = StoreWoodContext.Instace.CurrentStoreId;

            if (storeId == -1)
                return null;

            var managerDB = Context.Worker.Where(x => x.STORE_ID == storeId && x.MANAGER_ID == null).ToList();

            var managers = new List<Model.Worker>();

            foreach(var i in managerDB)
            {
                var manager = new Model.Worker();

                manager.Id = i.WORKER_ID;
                manager.Manager = null;
                manager.Name = i.first_name;
                manager.Position = GetWorkerPosition(i.WORKER_POSITION_ID);
                manager.Store = StoreWoodContext.Instace.Store.GetStore(i.STORE_ID);
                manager.Surname = i.second_name;

                managers.Add(manager);
            }

            return managers;
        }

        private Position GetWorkerPosition(int workerPosition)
        {
            var posDB = Context.WorkerPosition.Where(x => x.WORKER_POSITION_ID == workerPosition).FirstOrDefault();

            if (posDB == null)
                throw new Exception("Worker position is invalid, id = " + workerPosition);

            var pos = new Position();
            pos.ID = workerPosition;
            pos.name = posDB.position;

            return pos;
        }
    }
}
