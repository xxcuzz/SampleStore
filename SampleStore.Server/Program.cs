namespace SampleStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

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
