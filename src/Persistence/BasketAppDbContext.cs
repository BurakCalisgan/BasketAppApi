using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System;
using BasketAppApi.Domain.Entities;
using BasketAppApi.Domain.Common;
using BasketAppApi.Application.Common.Interfaces;

namespace BasketAppApi.Persistence
{
    public class BasketAppDbContext : DbContext, IBasketAppDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "CS";
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = "CS";
                        entry.Entity.UpdatedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=BasketApp; Integrated Security=true");

    }
}