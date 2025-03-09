using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SampleStore.Domain.ValueObjects;
using SampleStore.Infrastructure.Persistence.Entities;

namespace SampleStore.Infrastructure.Persistence.Configurations;

public class ArticleCollectionConfiguration : IEntityTypeConfiguration<ArticleCollection>
{
    public void Configure(EntityTypeBuilder<ArticleCollection> builder)
    {
        builder.ToTable("ArticleCollections");
        
        builder.HasKey(ac => new { ac.ArticleId, ac.CollectionId });
        builder.Property(ac => ac.ArticleId)
            .ValueGeneratedNever()
            .HasConversion(
                x => x.Value,
                x => ArticleId.Create(x));
        
        
        builder.Property(ac => ac.CollectionId)
            .ValueGeneratedNever()
            .HasConversion(
                x => x.Value,
                x => CollectionId.Create(x));
        
        builder.HasOne(ac => ac.Article).WithMany().HasForeignKey(ac => ac.ArticleId);
        builder.HasOne(ac => ac.Collection).WithMany().HasForeignKey(ac => ac.CollectionId);
    }
}