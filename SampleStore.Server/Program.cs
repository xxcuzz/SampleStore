using SampleStore.API.Extensions;
using SampleStore.API.Filters;
using SampleStore.Application.Extensions;
using SampleStore.Infrastructure.Extensions;

namespace SampleStore.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddApiServices();
        
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