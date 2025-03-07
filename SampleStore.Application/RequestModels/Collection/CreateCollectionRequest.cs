namespace SampleStore.Application.RequestModels.Collection;

public class CreateCollectionRequest
{
    public required string Name { get; set; }
    public List<Guid>? ArticleIds { get; set; }
}