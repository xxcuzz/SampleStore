using Microsoft.AspNetCore.Authentication;
using SampleStore.API.Extensions;
using SampleStore.Infrastructure.Extensions;

namespace SampleStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();
            builder.Services.AddControllers();

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            
            builder.Services.AddEndpointsApiExplorer();
            
            var app = builder.Build();

            app.UseDefaultFiles();
            app.MapStaticAssets();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("", () =>
            {
            });

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
