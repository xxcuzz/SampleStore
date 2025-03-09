using SampleStore.Domain.ArticleType;

namespace SampleStore.Application.RequestModels.Article;

public class CreateArticleRequest
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required List<Guid> CollectionIds { get; set; }
    public required ArticleTypeEnum ArticleType { get; set; }
}