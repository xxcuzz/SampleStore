using ErrorOr;
using MapsterMapper;
using Mediator;
using SampleStore.Application.Articles.Common;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Domain.Common.Errors;

namespace SampleStore.Application.Articles.Queries.GetArticlesByCategoryId;

public class GetArticlesByCategoryIdQueryHandler : IRequestHandler<GetArticlesByCategoryIdQuery, ErrorOr<List<ArticleResult>>>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IMapper _mapper;

    public GetArticlesByCategoryIdQueryHandler(IArticleRepository articleRepository, IMapper mapper)
    {
        _articleRepository = articleRepository;
        _mapper = mapper;
    }

    public async ValueTask<ErrorOr<List<ArticleResult>>> Handle(GetArticlesByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetArticlesByCategoryIdAsync(request.CategoryId, cancellationToken);
        if (articles.Count == 0)
        {
            return Errors.Article.ArticleNotFound();
        }

        var articlesResult = _mapper.Map<List<ArticleResult>>(articles);
        
        return articlesResult;
    }
}
