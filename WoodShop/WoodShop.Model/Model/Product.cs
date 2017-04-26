using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodShop.Model.Model
{
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }
    }
}
