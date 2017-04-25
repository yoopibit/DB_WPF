using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodShop.Model.Model
{
    public class Worker
    {
        public Store Store { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Position Position { get; set; }

        public Worker Manager { get; set; }

        public string GetManagerName { get
            {
                return Name + " " + Surname;
            }
        }

    }
}
