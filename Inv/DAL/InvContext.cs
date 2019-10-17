using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web.Configuration;
using Inv.Models;

namespace Inv.DAL
{
    public class InvContext : DbContext
    {

        public InvContext() : base("InvContext")
        {
        }

        public DbSet<Category> Categories{ get; set; }
        public DbSet<Product> Products{ get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}