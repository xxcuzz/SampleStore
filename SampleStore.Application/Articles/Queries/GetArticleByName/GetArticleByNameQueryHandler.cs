using ErrorOr;
using MapsterMapper;
using MediatR;

using SampleStore.Application.Articles.Common;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Common.Errors;
using SampleStore.Domain.Entities;

namespace SampleStore.Application.Articles.Queries.GetArticleByName;

public class GetArticleByNameQueryHandler : IRequestHandler<GetArticleByNameQuery, ErrorOr<ArticleResult>>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IMapper _mapper;

    public GetArticleByNameQueryHandler(IArticleRepository articleRepository, IMapper mapper)
    {
        _articleRepository = articleRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ArticleResult>> Handle(GetArticleByNameQuery query, CancellationToken cancellationToken)
    {
        if (await _articleRepository.Async(query.Name) is not Article article)
        {
            return Errors.Article.ArticleNotFound();
        }
        
        var articleDto = _mapper.Map<ArticleDto>(article);
        
        return new ArticleResult(articleDto);
    }
}