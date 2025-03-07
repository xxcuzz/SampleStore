namespace SampleStore.Application.Models.DTO;

public record ArticleDto(Guid Id, string Name, decimal OriginalPrice, decimal DiscountedPrice, List<Guid>? CollectionIds);