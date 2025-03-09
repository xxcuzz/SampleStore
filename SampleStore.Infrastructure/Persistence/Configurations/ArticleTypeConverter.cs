using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using SampleStore.Domain.ArticleType;

namespace SampleStore.Infrastructure.Persistence.Configurations;

public class ArticleTypeConverter : ValueConverter<ArticleTypeEnum, string>
{
    public ArticleTypeConverter() : base(
        v => v.ToString(),
        v => Enum.Parse<ArticleTypeEnum>(v))
    {
    }
}