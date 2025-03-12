using ErrorOr;
using MapsterMapper;
using Mediator;

using SampleStore.Application.Articles.Common;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Domain.Common.Errors;

namespace SampleStore.Application.Articles.Queries.GetArticlesByCollectionId;

public class GetArticlesByCollectionIdQueryHandler :
    IRequestHandler<GetArticlesByCollectionIdQuery, ErrorOr<List<ArticleResult>>>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IMapper _mapper;

    public GetArticlesByCollectionIdQueryHandler(IArticleRepository articleRepository, IMapper mapper)
    {
        _articleRepository = articleRepository;
        _mapper = mapper;
    }

    public async ValueTask<ErrorOr<List<ArticleResult>>> Handle(GetArticlesByCollectionIdQuery request,
        CancellationToken cancellationToken)
    {
        var articleDtoSlims =
            await _articleRepository.GetArticlesByCollectionIdAsync(request.CollectionId, cancellationToken);
        if (articleDtoSlims.Count == 0)
        {
            return Errors.Article.ArticleNotFound();
        }
        
        var articlesResult = _mapper.Map<List<ArticleResult>>(articleDtoSlims);
        return articlesResult;
    }
}
