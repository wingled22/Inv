namespace Inv.Migrations
{
    using Inv.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Inv.DAL.InvContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Inv.DAL.InvContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var cats = new List<Category> {
                new Category{ CategoryName = "Barbeque"},
                new Category{ CategoryName = "Tea"},
                new Category{ CategoryName = "Juice"},
                new Category{ CategoryName = "Burger"},
                new Category{ CategoryName = "Juice"},
                new Category{ CategoryName = "Cake"},
            };
            cats.ForEach(s => context.Categories.AddOrUpdate(s));
            context.SaveChanges();

        }
    }
}
