using ErrorOr;

namespace SampleStore.Domain.Common.Errors;

public static partial class Errors
{
    public static class Article
    {
        public static Error ArticleNotFound() =>
            Error.NotFound(
                code: "article.article_not_found",
                description: "Article Not Found");
    }
}
