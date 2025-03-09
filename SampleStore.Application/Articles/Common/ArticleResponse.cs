namespace SampleStore.Application.Articles.Common;

public record ArticleResponse(
    Guid Id,
    string Name,
    decimal OriginalPrice,
    decimal DiscountedPrice,
    List<string> CollectionIds);