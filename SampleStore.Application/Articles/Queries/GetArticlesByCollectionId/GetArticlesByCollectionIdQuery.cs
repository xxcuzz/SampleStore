using ErrorOr;
using Mediator;
using SampleStore.Application.Articles.Common;

namespace SampleStore.Application.Articles.Queries.GetArticlesByCollectionId;

public record GetArticlesByCollectionIdQuery(Guid CollectionId) : IRequest<ErrorOr<List<ArticleResult>>>;
