using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SampleStore.Application.Common.Behaviors;
using SampleStore.Application.Common.Mappings;

namespace SampleStore.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddMappings();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }    
}