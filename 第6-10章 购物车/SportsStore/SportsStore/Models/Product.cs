using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Models
{
    public class Product
    {
        public Int32 ProductID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public int Store { get; set; }
        public String Category { get; set; }
    }
}