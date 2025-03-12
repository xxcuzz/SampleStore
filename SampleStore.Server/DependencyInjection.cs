namespace SampleStore.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddProblemDetails();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularDev", builder =>
                builder.WithOrigins("https://localhost:59175")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });
        
        return services;
    }
}
