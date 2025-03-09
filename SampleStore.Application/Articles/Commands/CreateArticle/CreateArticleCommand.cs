using ErrorOr;
using MediatR;

using SampleStore.Application.Articles.Common;
using SampleStore.Domain.ArticleType;

namespace SampleStore.Application.Articles.Commands.CreateArticle;

public record CreateArticleCommand(string Name, decimal Price, List<Guid> CollectionIds, ArticleTypeEnum ArticleType)
    : IRequest<ErrorOr<ArticleResult>>;