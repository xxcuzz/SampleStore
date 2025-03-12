using ErrorOr;
using MapsterMapper;
using Mediator;
using SampleStore.Application.Collections.Common;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Domain.Common.Errors;

namespace SampleStore.Application.Collections.Queries.GetCollections;

public class GetCollectionsQueryHandler : IRequestHandler<GetCollectionsQuery, ErrorOr<List<CollectionResult>>>
{
    private readonly ICollectionRepository _collectionRepository;
    private readonly IMapper _mapper;

    public GetCollectionsQueryHandler(ICollectionRepository collectionRepository, IMapper mapper)
    {
        _collectionRepository = collectionRepository;
        _mapper = mapper;
    }
    
    public async ValueTask<ErrorOr<List<CollectionResult>>> Handle(GetCollectionsQuery request, CancellationToken cancellationToken)
    {
        var collections = await _collectionRepository.GetCollectionsAsync(cancellationToken);
        if (collections.Count == 0)
        {
            return Errors.Collection.CollectionListIsEmpty();
        }
        
        var collectionResults = _mapper.Map<List<CollectionResult>>(collections);
        return collectionResults;
    }
}
