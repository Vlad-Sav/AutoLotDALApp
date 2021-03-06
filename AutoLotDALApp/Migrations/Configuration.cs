namespace AutoLotDALApp.Migrations
{
    using AutoLotDALApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutoLotDALApp.EF.AutoLotEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AutoLotDALApp.EF.AutoLotEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var customers = new List<Customers>
            {
                new Customers {FirstName = "Dave", LastName = "Brenner"},
                new Customers {FirstName = "Matt", LastName = "Walton"},
                new Customers {FirstName = "Steve", LastName = "Hagen"},
                new Customers {FirstName = "Pat", LastName = "Walton"},
                new Customers {FirstName = "Bad", LastName = "Customer"},
            };
            customers.ForEach(x => context.Customers.AddOrUpdate(
                c => new { c.FirstName, c.LastName }, x));
            var cars = new List<Inventory>
            {
                new Inventory {Make = "VW", Color = "Black", PetName = "Zippy"},
                new Inventory {Make = "Ford", Color = "Rust", PetName = "Rusty"},
                new Inventory {Make = "Saab", Color = "Black", PetName = "Mel"},
                new Inventory {Make = "Yugo", Color = "Yellow", PetName = "Clunker"},
                new Inventory {Make = "BMW", Color = "Black", PetName = "Bimmer"},
                new Inventory {Make = "BMW", Color = "Green", PetName = "Hank"},
                new Inventory {Make = "BMW", Color = "Pink", PetName = "Pinky"},
                new Inventory {Make = "Pinto", Color = "Black", PetName = "Pete"},
                new Inventory {Make = "Yugo", Color = "Brown", PetName = "Brownie"},
            };
            context.Inventory.AddOrUpdate(x => new { x.Make, x.Color }, cars.ToArray());
            var orders = new List<Orders>
            {
                new Orders {Car = cars[0], Customers = customers[0]},
                new Orders {Car = cars[1], Customers = customers[1]},
                new Orders {Car = cars[2], Customers = customers[2]},
                new Orders {Car = cars[3], Customers = customers[3]},
            };
            orders.ForEach(x => context.Orders.AddOrUpdate(c => new { c.CarId, c.CustId }, x));

            context.CreditRisks.AddOrUpdate(x => new { x.FirstName, x.LastName },
                new CreditRisk
                {
                    Id = customers[4].Id,
                    FirstName = customers[4].FirstName,
                    LastName = customers[4].LastName,
                });
        }
    }
}
