using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inv.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual Category Category{ get; set; }
    }
}