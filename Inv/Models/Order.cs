using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inv.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Transaction Transaction { get; set; }
        public virtual Product Product{ get; set; }
    }
}