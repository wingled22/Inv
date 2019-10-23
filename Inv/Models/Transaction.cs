using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inv.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        [Required]
        [Display(Name ="Completed")]
        public bool Status { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}