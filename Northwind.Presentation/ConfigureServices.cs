using Microsoft.Extensions.DependencyInjection;

namespace Northwind.Presentation;

public static class ConfigureServices
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        var builder = services.AddMvcCore();
        builder.AddApplicationPart(typeof(ConfigureServices).Assembly);
        // services.AddPersistenceServices();
        // services.AddApplicationServices();
        // services.AddDomainServices();
        return services;
    }
}