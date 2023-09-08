using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Data;
using Northwind.Persistence.Repositories;

namespace Northwind.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<MasterContext>(
            options => options.UseSqlServer(
                "Server=localhost;Database=master;User Id=sa;Password=<YourStrong@Passw0rd>;TrustServerCertificate=True"));
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        return services;
    }
}