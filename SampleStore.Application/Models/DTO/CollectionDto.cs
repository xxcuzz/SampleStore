namespace SampleStore.Application.Models.DTO;

public record CollectionDto(Guid Id, string Name, List<Guid>? ArticleIds);