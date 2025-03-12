using SampleStore.Application;
using SampleStore.Infrastructure;
using SampleStore.Infrastructure.Persistence.Dapper.DatabaseInitWork;

namespace SampleStore.API;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddApiServices()
            .AddInfrastructureServices(builder.Configuration)
            .AddApplicationServices();

        var app = builder.Build();
        
        app.UseDefaultFiles();
        app.MapStaticAssets();
        app.UseExceptionHandler("/error");
        app.UseHttpsRedirection();
        
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.MapFallbackToFile("/index.html");
        
        app.UseCors("AllowAngularDev");

        var databaseInitializer = app.Services.GetRequiredService<DatabaseMigrator>();
        await databaseInitializer.InitializeAsync();
        
        bool isDbSeedNeeded = builder.Configuration.GetValue<bool>("SeedDatabaseIfEmptyOnStartup");

        if (isDbSeedNeeded)
        {
            var databaseSeeder = app.Services.GetRequiredService<DatabaseOperations>();
            databaseSeeder.SeedDatabase();
        }
        
        app.Run();
    }
}
