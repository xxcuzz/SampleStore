using ErrorOr;
using MapsterMapper;
using Mediator;

using SampleStore.Application.Articles.Common;
using SampleStore.Application.Common.Interfaces.Persistence;

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

    public async ValueTask<ErrorOr<ArticleResult>> Handle(GetArticleByNameQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        // if (await _articleRepository.GetArticleByNameAsync(query.Name) is not ArticleSlimDto article)
        // {
        //     return Errors.Article.ArticleNotFound();
        // }
        //
        // var articleDto = _mapper.Map<ArticleSlimDto>(article);
        //
        // return new ArticleResult(articleDto.Id);
    }
}
