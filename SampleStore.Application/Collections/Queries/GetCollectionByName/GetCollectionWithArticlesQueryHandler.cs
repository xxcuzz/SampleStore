using ErrorOr;
using MapsterMapper;
using MediatR;

using SampleStore.Application.Collections.Common;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Common.Errors;
using SampleStore.Domain.Entities;

namespace SampleStore.Application.Collections.Queries.GetCollectionByName;

public class GetCollectionWithArticlesQueryHandler : IRequestHandler<GetCollectionWithArticlesQuery, ErrorOr<CollectionResult>>
{
    private readonly ICollectionRepository _collectionRepository;
    private readonly IMapper _mapper;

    public GetCollectionWithArticlesQueryHandler(ICollectionRepository collectionRepository, IMapper mapper)
    {
        _collectionRepository = collectionRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<CollectionResult>> Handle(GetCollectionWithArticlesQuery query,
        CancellationToken cancellationToken)
    {
        if (_collectionRepository.GetCollectionWithArticles(query.Name) is not Collection collection)
        {
            return Errors.Collection.CollectionNotFound();
        }
        
        var collectionDto = _mapper.Map<CollectionDto>(collection);
        
        return new CollectionResult(collectionDto);
    }
}