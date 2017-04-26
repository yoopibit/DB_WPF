using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodShop.Model.Model
{
    public class OrderDetail
    {
        public Model.Product Product { get; set; }

        public int Number { get; set; }
    }

    public class Order
    {
        public string WorkerName { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<OrderDetail> Products { get; set; }
    }
}
