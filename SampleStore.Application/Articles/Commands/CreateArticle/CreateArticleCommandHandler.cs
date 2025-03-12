using ErrorOr;
using MapsterMapper;
using Mediator;

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

    public async ValueTask<ErrorOr<ArticleResult>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // TODO redo
        // var existingCollectionsIds = await _collectionRepository.GetAllIdsAsync();
        //
        // if (existingCollectionsIds == null || existingCollectionsIds.Count == 0)
        // {
        //     return Errors.Collection.CollectionListIsEmpty();
        // }
        //
        // var invalidCollectionIds = request.CollectionIds.Except(existingCollectionsIds);
        //
        // if (invalidCollectionIds.Any())
        // {
        //     return Errors.Collection.CollectionNotFound();
        // }
        
        var collectionIds = request.CollectionIds
            .Select(id => CollectionId.Create(id))
            .ToList();
        
        var article = Article.Create(request.Name, request.Price, collectionIds, null);
        await _articleRepository.AddAsync(article);
        
        var articleDto = _mapper.Map<ArticleDtoSlim>(article);
        
        return new ArticleResult(articleDto);
    }
}
