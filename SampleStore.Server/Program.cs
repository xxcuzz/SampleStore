using SampleStore.Application;
using SampleStore.Infrastructure;

namespace SampleStore.API;

public class Program
{
    public static void Main(string[] args)
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
        
        app.UseAuthorization();
        app.MapControllers();
        
        app.MapGet("", () =>
        {
        });

        app.MapFallbackToFile("/index.html");

        app.Run();
    }
}