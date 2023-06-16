using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Behaviors;

namespace Northwind.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(AssemblyReference.Assembly);

        // Validation Pipeline
        services.AddScoped(typeof(IPipelineBehavior<,>),
            typeof(ValidationPipelineBehavior<,>));

        services.AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);

        return services;
    }
}