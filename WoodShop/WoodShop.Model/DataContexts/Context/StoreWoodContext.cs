﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodShop.Model.DataContexts.Context;

namespace WoodShop.Model.DataContexts.Context
{
    public interface IStoreWoodDbContext
    {
        IWorkerDbContext Worker { get; set; }

        IStores Store { get; set; }

        IPositions Position { get; set; }

        int CurrentStoreId { get; set; }
    }


    public class StoreWoodContext : IStoreWoodDbContext
    {
        private Store_wood_productsEntities1 _Context = new Store_wood_productsEntities1();

        private static IStoreWoodDbContext _Instance;

        public static IStoreWoodDbContext Instace
        {
            get
            {
                return _Instance ?? (_Instance = new StoreWoodContext());
            }
            set
            {
                _Instance = value;
            }
        }

        private StoreWoodContext()
        {
            try
            {
                _Context.Database.Exists();
            }
            catch(Exception ex)
            {
                throw new Exception("No data connection!" + ex.Message);
            }

            Worker = new Worker(_Context);
            Store = new Stores(_Context);
            Position = new Positions(_Context);
            CurrentStoreId = -1;
        }

        public IWorkerDbContext Worker { get; set; }

        public int CurrentStoreId { get; set; }

        public IStores Store { get; set; }

        public IPositions Position { get; set; }
    }
}
