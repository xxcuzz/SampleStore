using ErrorOr;
using Mediator;

using SampleStore.Application.Articles.Common;

namespace SampleStore.Application.Articles.Queries.GetArticlesByCategoryId;

public record GetArticlesByCategoryIdQuery(Guid CategoryId) : IRequest<ErrorOr<List<ArticleResult>>>;
