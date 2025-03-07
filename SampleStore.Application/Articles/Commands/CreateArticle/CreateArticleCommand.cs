using ErrorOr;
using MediatR;

using SampleStore.Application.Articles.Common;

namespace SampleStore.Application.Articles.Commands.CreateArticle;

public record CreateArticleCommand(string Name, decimal Price, List<Guid> CollectionIds)
    : IRequest<ErrorOr<ArticleResult>>;