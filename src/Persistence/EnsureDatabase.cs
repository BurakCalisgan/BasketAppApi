
using System;
using System.Linq;
using BasketAppApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasketAppApi.Persistence
{
    public static class EnsureDatabase
    {
        public static void Ensure()
        {
            var context = new BasketAppDbContext();
            context.Database.Migrate();

            if (!context.Baskets.Any())
            {
                context.Baskets.Add(new Basket { UserId = System.Guid.NewGuid().ToString() });
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product()
                    {
                        Name = "Product 1",
                        Price = 10,
                        Quantity = 10,
                        CreatedBy = "CS",
                        CreatedDate = DateTime.Now,
                        UpdatedBy = "CS",
                        UpdatedDate = DateTime.Now
                    },
                     new Product()
                    {
                        Name = "Product 2",
                        Price = 10,
                        Quantity = 10,
                        CreatedBy = "CS",
                        CreatedDate = DateTime.Now,
                        UpdatedBy = "CS",
                        UpdatedDate = DateTime.Now
                    }

                );
                context.SaveChanges();
            }
        }
    }
}