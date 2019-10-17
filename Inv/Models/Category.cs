using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inv.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}