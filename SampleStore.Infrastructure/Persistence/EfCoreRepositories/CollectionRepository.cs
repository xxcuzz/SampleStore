using Microsoft.EntityFrameworkCore;

using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Domain.Entities;

namespace SampleStore.Infrastructure.Persistence.EfCoreRepositories;

public class CollectionRepository : ICollectionRepository
{
    private readonly SampleStoreDbContext _dbContext;

    public CollectionRepository(SampleStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Collection collection)
    {
        await _dbContext.Collections.AddAsync(collection);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Collection?> GetCollectionWithArticlesAsync(string name)
    {
        var collection = await _dbContext.Collections.FindAsync(name);
        return collection;
    }

    public async Task<List<Guid>?> GetAllIdsAsync()
    {
        var collections = await _dbContext.Collections.Select(x => x.Id.Value).ToListAsync();
        return collections;
    }
}