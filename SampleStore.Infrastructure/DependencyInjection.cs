using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleStore.Application.Common.Interfaces.Authentication;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Application.Common.Interfaces.Services;
using SampleStore.Infrastructure.Authentication;
using SampleStore.Infrastructure.Persistence.EfCoreRepositories;
using SampleStore.Infrastructure.Services;

namespace SampleStore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        services.AddScoped<IUserRepository,UserRepository>();
        return services;
    }
}