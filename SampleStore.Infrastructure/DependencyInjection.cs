using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SampleStore.Application.Common.Interfaces.Authentication;
using SampleStore.Application.Common.Interfaces.Services;
using SampleStore.Infrastructure.Authentication;
using SampleStore.Infrastructure.Persistence.Dapper;
using SampleStore.Infrastructure.Services;

namespace SampleStore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddAuth(configuration)
            .AddPersistence(configuration);
        
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDapper(configuration);
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.Section, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        
        return services;
    }
}
