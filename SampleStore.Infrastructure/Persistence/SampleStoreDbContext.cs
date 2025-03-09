using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using SampleStore.Domain.Entities;
using SampleStore.Domain.ValueObjects;

namespace SampleStore.Infrastructure.Persistence;

public class SampleStoreDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public SampleStoreDbContext(DbContextOptions<SampleStoreDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }
    
    public DbSet<Article> Articles { get; set; }
    public DbSet<Collection> Collections { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration["PostgresConnectionString"]!);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampleStoreDbContext).Assembly);
        modelBuilder.Ignore<ArticleId>();
        modelBuilder.Ignore<CollectionId>();
        base.OnModelCreating(modelBuilder);
    }
}