using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Domain.Entities;
using SampleStore.Domain.ValueObjects;

namespace SampleStore.Infrastructure.Persistence.EfCoreRepositories;

public class CollectionRepository : ICollectionRepository
{
    public void Add(Collection collection)
    {
        // TODO
        return;
    }

    public Collection? GetCollectionWithArticles(string name)
    {
        // TODO
        return Collection.Create(name);
        return null;
    }
}