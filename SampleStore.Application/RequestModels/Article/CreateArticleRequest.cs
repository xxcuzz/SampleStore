namespace SampleStore.Application.RequestModels.Article;

public class CreateArticleRequest
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required List<Guid> CollectionIds { get; set; }
    
    public required Guid CategoryId { get; set; }
}