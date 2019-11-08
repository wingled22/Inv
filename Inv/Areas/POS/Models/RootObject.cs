using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inv.Areas.POS.Models
{
    public class RootObject
    {
        public int? ProductID { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}