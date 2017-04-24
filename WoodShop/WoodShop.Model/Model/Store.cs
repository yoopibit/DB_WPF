using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodShop.Model.Model
{
    public class StoreAddress
    {
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string building { get; set; }

        public string Address
        {
            get
            {
                return country + " " + city + " " + street + " " + building; 
            }
        }
    }

    public class Store
    {
        public int id { get; set; }

        public StoreAddress address { get; set; }

        public string description { get; set; }

        public string GetName
        {
            get
            {
                string desc = description == null ? "": description;
                return  desc + address.Address;
            }
        }
    }
}
