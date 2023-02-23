using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Northwind.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(AssemblyReference.Assembly);
        return services;
    }
}