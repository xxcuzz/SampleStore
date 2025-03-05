using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using SampleStore.Application.Common.Interfaces.Authentication;
using SampleStore.Application.Services;

namespace SampleStore.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IMapper, Mapper>();
        
        return services;
    }
}