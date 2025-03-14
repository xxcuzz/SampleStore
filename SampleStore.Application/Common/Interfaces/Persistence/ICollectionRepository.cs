using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Entities;

namespace SampleStore.Application.Common.Interfaces.Persistence;

public interface ICollectionRepository
{
    Task AddAsync(Collection collection);
    
    Task<List<CollectionDtoSlim>> GetCollectionsAsync(CancellationToken cancellationToken = default);
}
