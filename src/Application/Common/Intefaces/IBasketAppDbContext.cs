using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using BasketAppApi.Domain.Entities;

namespace BasketAppApi.Application.Common.Interfaces
{
    public interface IBasketAppDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}