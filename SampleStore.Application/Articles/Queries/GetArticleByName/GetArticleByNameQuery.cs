using ErrorOr;
using Mediator;

using SampleStore.Application.Articles.Common;

namespace SampleStore.Application.Articles.Queries.GetArticleByName;

public record GetArticleByNameQuery(string Name) : IRequest<ErrorOr<ArticleResult>>;