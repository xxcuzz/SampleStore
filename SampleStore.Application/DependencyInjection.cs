using System.Reflection;
using FluentValidation;
using Mediator;

using Microsoft.Extensions.DependencyInjection;
using SampleStore.Application.Common.Behaviors;
using SampleStore.Application.Common.Mappings;

namespace SampleStore.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediator(lt => lt.ServiceLifetime = ServiceLifetime.Scoped);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMappings();
        
        return services;
    }    
}
