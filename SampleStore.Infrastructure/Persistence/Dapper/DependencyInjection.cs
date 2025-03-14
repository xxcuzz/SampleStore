using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Infrastructure.Persistence.Dapper.DatabaseInitWork;
using SampleStore.Infrastructure.Persistence.Dapper.Repositories;

namespace SampleStore.Infrastructure.Persistence.Dapper;

public static  class DependencyInjection
{
    public static IServiceCollection AddDapper(this IServiceCollection services,
        IConfiguration configuration)
    {
        var environment = configuration["ASPNETCORE_ENVIRONMENT"];
        services.AddSingleton<IDbConnectionFactory>(_ =>
            new NpgSqlConnectionFactory(configuration["PostgresConnectionString"]!));
        services.AddSingleton(_ => new DatabaseMigrator(configuration["PostgresConnectionString"]!));
        
        services.AddSingleton(_ => new DatabaseOperations(configuration["PostgresConnectionString"]!));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<ICollectionRepository, CollectionRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        return services;
    }
}
