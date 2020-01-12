using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inv.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Quantity Per Unit")]
        public string QuantityPerUnit { get; set; }

        [Required]
        public int Stocks { get; set; }

        public decimal Price { get; set; }

        [Required]
        public bool Available { get; set; }

        public virtual Category Category{ get; set; }
    }
}