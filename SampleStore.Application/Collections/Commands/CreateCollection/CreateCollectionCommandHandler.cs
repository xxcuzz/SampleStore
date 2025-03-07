using ErrorOr;
using MapsterMapper;
using MediatR;

using SampleStore.Application.Collections.Common;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Entities;
using SampleStore.Domain.ValueObjects;

namespace SampleStore.Application.Collections.Commands.CreateCollection;

public class CreateCollectionCommandHandler : IRequestHandler<CreateCollectionCommand, ErrorOr<CollectionResult>>
{
    private readonly ICollectionRepository _collectionRepository;
    private readonly IMapper _mapper;

    public CreateCollectionCommandHandler(ICollectionRepository collectionRepository, IMapper mapper)
    {
        _collectionRepository = collectionRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<CollectionResult>> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var articlesIds = request.ArticleIds?.Select(id => ArticleId.Create(id)).ToList();
        var collection = Collection.Create(request.Name, articlesIds);
        _collectionRepository.Add(collection);
        var collectionDto = _mapper.Map<CollectionDto>(collection);
        
        return new CollectionResult(collectionDto);
    }
}