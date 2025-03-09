using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SampleStore.Domain.Entities;
using SampleStore.Domain.ValueObjects;

namespace SampleStore.Infrastructure.Persistence.Configurations;

public class ArticleConfigurations : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                x => x.Value,
                x => ArticleId.Create(x));
        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.OwnsOne(x => x.Price, priceBuilder =>
        {
            priceBuilder.Property(x => x.OriginalPrice).HasColumnType("decimal(6, 2)").IsRequired();
            priceBuilder.Property(p => p.DiscountedPrice).HasColumnName("DiscountedPrice");
        });
        
        builder.Property(x=>x.ArticleType)
            .HasConversion<int>()
            .IsRequired();
    }
}