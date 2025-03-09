using SampleStore.Domain.Entities;

namespace SampleStore.Application.Common.Interfaces.Persistence;

public interface ICollectionRepository
{
    Task AddAsync(Collection collection);

    Task<Collection?> GetCollectionWithArticlesAsync(string name);
    
    Task<List<Guid>?> GetAllIdsAsync();
}