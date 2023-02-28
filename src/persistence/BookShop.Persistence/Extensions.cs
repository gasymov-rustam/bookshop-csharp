using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Persistence;

public static class Extensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookShopDbContext>(options =>
        {
            options.UseSqlServer(configuration["ConnectionString"]);
        });

        return services;
    }
}