using Microsoft.Extensions.DependencyInjection;
using SampleStore.Application.Interfaces;
using SampleStore.Application.Services;

namespace SampleStore.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}