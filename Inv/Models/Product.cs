using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inv.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public int Stocks { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }
            
        public virtual Category Category{ get; set; }
    }
}