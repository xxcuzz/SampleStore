using ErrorOr;
using MapsterMapper;
using MediatR;

using SampleStore.Application.Articles.Common;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Entities;
using SampleStore.Domain.ValueObjects;

namespace SampleStore.Application.Articles.Commands.CreateArticle;

public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, ErrorOr<ArticleResult>>
{
    private readonly IArticleRepository _articleRepository;
    private readonly ICollectionRepository _collectionRepository;
    private readonly IMapper _mapper;
    
    public CreateArticleCommandHandler(IArticleRepository articleRepository, ICollectionRepository collectionRepository, IMapper mapper)
    {
        _articleRepository = articleRepository;
        _collectionRepository = collectionRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ArticleResult>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var collectionIds = request.CollectionIds
            .Select(id => CollectionId.Create(id))
            .ToList();
        
        var price = Price.Create(request.Price);
        
        var article = Article.Create(request.Name, price, collectionIds);
        _articleRepository.Add(article);
        
        var articleDto = _mapper.Map<ArticleDto>(article);
        
        return new ArticleResult(articleDto);
    }
}