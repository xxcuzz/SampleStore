namespace SampleStore.Application.Collections.Common;

public record CollectionResponse(Guid Id, string Name, List<Guid> ArticleIds);