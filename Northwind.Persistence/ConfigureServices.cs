using Microsoft.Extensions.DependencyInjection;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Data;
using Northwind.Persistence.Repositories;

namespace Northwind.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddSingleton<MasterContext>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        return services;
    }
}