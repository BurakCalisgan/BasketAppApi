using Microsoft.Extensions.DependencyInjection;
using BasketAppApi.Application.Common.Interfaces;

namespace BasketAppApi.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<BasketAppDbContext>();
            services.AddScoped<IBasketAppDbContext>(provider => provider.GetService<BasketAppDbContext>());
            return services;
        }
    }
}