using Microsoft.EntityFrameworkCore;
namespace SportsStore.Models
{
    public static class SeedData
    {
        //wywolujemy pozniej tą metodę w program.cs
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            //create database migrations if they were not created
            if (!context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if(!context.Departments.Any())
            {
                context.Departments.AddRange(
                    new Department
                    {
                        Name = "Soccer"
                    },
                    new Department
                    {
                        Name = "Bikes"
                    },
                    new Department
                    {
                        Name = "Swimming"
                    }
                    );
                context.SaveChanges();

            }
            //add products when they were not any in the database
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new Product
                {
                    Name = "Kayak",
                    Description = "A boat for one person",
                    DepartmentID = 2,
                    Price = 275
                },
                new Product
                {
                    Name = "Lifejacket",
                    Description = "Protective and fashionable",
                    DepartmentID = 1,
                    Price = 48.95m
                },
                new Product
                {
                    Name = "Soccer Ball",
                    Description = "FIFA-approved size and weight",
                    DepartmentID = 1,
                    Price = 19.50m
                },
                new Product
                {
                    Name = "Corner Flags",
                    Description = "Give your playing field a professional touch",
                    DepartmentID = 3,
                    Price = 34.95m
                },
                new Product
                {
                    Name = "Stadium",
                    Description = "Flat-packed 35,000-seat stadium",
                    DepartmentID = 3,
                    Price = 79500
                },
                new Product
                {
                    Name = "Thinking Cap",
                    Description = "Improve brain efficiency by 75%",
                    DepartmentID = 2,
                    Price = 16
                },
                new Product
                {
                    Name = "Unsteady Chair",
                    Description = "Secretly give your opponent a disadvantage",
                    DepartmentID = 2,
                    Price = 29.95m
                },
                new Product
                {
                    Name = "Human Chess Board",
                    Description = "A fun game for the family",
                    DepartmentID = 3,
                    Price = 75
                },
                new Product
                {
                    Name = "Bling-Bling King",
                    Description = "Gold-plated, diamond-studded King",
                    DepartmentID = 1,
                    Price = 1200
                }
                );
                context.SaveChanges();
            }
        }
    }
}