using ErrorOr;
using MediatR;

using SampleStore.Application.Articles.Common;
using SampleStore.Domain.ArticleType;

namespace SampleStore.Application.Articles.Queries.GetArticlesByType;

public record GetArticlesByTypeQuery(ArticleTypeEnum articleType) :  IRequest<ErrorOr<List<ArticleResult>>>;