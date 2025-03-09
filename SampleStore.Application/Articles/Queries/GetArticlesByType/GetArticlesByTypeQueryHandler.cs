using ErrorOr;

using MapsterMapper;

using MediatR;

using SampleStore.Application.Articles.Common;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Common.Errors;

namespace SampleStore.Application.Articles.Queries.GetArticlesByType;

public class GetArticlesByTypeQueryHandler : IRequestHandler<GetArticlesByTypeQuery, ErrorOr<List<ArticleResult>>>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IMapper _mapper;

    public GetArticlesByTypeQueryHandler(IArticleRepository articleRepository, IMapper mapper)
    {
        _articleRepository = articleRepository;
        _mapper = mapper;
    }
    
    public async Task<ErrorOr<List<ArticleResult>>> Handle(GetArticlesByTypeQuery query,
        CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetArticlesByTypeAsync(query.articleType);
        if (!articles.Any())
        {
            return Errors.Article.ArticleNotFound();
        }

        var articleDtoList = _mapper.Map<List<ArticleDto>>(articles);
        var articleResults = articleDtoList.Select(_mapper.Map<ArticleResult>).ToList();

        return articleResults;
    }
}