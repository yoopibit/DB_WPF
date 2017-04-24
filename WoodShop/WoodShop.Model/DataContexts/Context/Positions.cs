using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodShop.Model.Model;

namespace WoodShop.Model.DataContexts.Context
{
    public interface IPositions
    {
        IEnumerable<Model.Position> GetAll();
    }
    class Positions : IPositions
    {
        private Store_wood_productsEntities1 Context { get; set; }

        public Positions(Store_wood_productsEntities1 dbContext)
        {
            Context = dbContext;
        }

        public IEnumerable<Position> GetAll()
        {
            var positionsFromDB = Context.WorkerPosition.ToList();

            var positions = new List<Model.Position>();

            foreach (var i in positionsFromDB)
            {
                var pos = new Model.Position();

                pos.ID = i.WORKER_POSITION_ID;
                pos.name = i.position;

                positions.Add(pos);
            }

            return positions;
        }
    }
}
