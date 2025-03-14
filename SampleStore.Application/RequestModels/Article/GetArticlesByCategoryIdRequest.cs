namespace SampleStore.Application.RequestModels.Article;

public class GetArticlesByCategoryIdRequest
{
    public required Guid CategoryId { get; set; }
}
