using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

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
            if (!context.Departments.Any())
            {
                context.Departments.AddRange(
                    new Department
                    {
                        Name = "Soccer",
                        Description = "Here you can find everything you need to play and train soccer."
                    },
                    new Department
                    {
                        Name = "Swimming",
                        Description = "Here you can find everything you need to swim like professional swimmer."
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
                    Name = "Training Ball",
                    Description = "Training ball is ideal for gruelling sessions. Its machine-stitched construction and butyl bladder ensure resilience and longevity. ",
                    DepartmentID = 1,
                    Price = 120
                },
                new Product
                {
                    Name = "Traning Gloves",
                    Description = "Designed to perform in all the right places.",
                    DepartmentID = 1,
                    Price = 60
                },
                new Product
                {
                    Name = "Pro Gloves",
                    Description = "These goalkeeper gloves have a silicone Zone Skin coating on their adaptive knit backhand to help you clear the ball. ",
                    DepartmentID = 1,
                    Price = 300
                },
                new Product
                {
                    Name = "Corner Flags",
                    Description = "Give your playing field a professional touch",
                    DepartmentID = 1,
                    Price = 34.95m
                },
                new Product
                {
                    Name = "Stadium",
                    Description = "Flat-packed 35,000-seat stadium",
                    DepartmentID = 1,
                    Price = 79500
                },
                new Product
                {
                    Name = "Thinking Cap",
                    Description = "Improve brain efficiency by 75%",
                    DepartmentID = 1,
                    Price = 16
                },
                new Product
                {
                    Name = "Shin Guards",
                    Description = "They're backed with molded, perforated EVA for comfortable cushioning and enhanced shock absorption. A compression sleeve holds everything in place so you stay one step ahead.",
                    DepartmentID = 1,
                    Price = 75.95m
                },
                new Product
                {
                    Name = "Silicone Cap",
                    Description = "Offers a lightweight fit with total comfort and durability from the elements, perfect for training and competitions.",
                    DepartmentID = 2,
                    Price = 35.95m
                },
                new Product
                {
                    Name = "Aqua Breaker Cap",
                    Description = "Offers a lightweight fit with total comfort and durability from the elements, perfect for training and competitions.",
                    DepartmentID = 2,
                    Price = 55.95m
                },
                 new Product
                 {
                     Name = "Aero Goggles Adults",
                     Description = "Feature a streamline look with a silicone seal to stop the water interfering with your performance. ",
                     DepartmentID = 2,
                     Price = 75.95m
                 },
                  new Product
                  {
                      Name = "Velour Towel",
                      Description = "The Team Velour Towel offers a great look thanks to the team crest and styling, whilst the soft cotton construction allows for a comfortable feel.",
                      DepartmentID = 2,
                      Price = 64.95m
                  },
                   new Product
                   {
                       Name = "Aqua Dumbbells",
                       Description = "These Aqua Dumbbells are crafted in a lightweight, foam construction. Perfect for a workout in the pool.",
                       DepartmentID = 2,
                       Price = 40.95m
                   },
                    new Product
                    {
                        Name = "Swim Seat 1-2 Inflatable Infants",
                        Description = "The swim seat is the ideal product for introducing your child to the water and improving their confidence. It meets all relevant European safety standards and is made from a low phthalate PVC, which is safer and more child friendly.",
                        DepartmentID = 2,
                        Price = 91.95m
                    }
                );
                context.SaveChanges();
            }
        }
    }
}