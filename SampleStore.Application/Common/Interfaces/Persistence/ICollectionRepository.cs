using SampleStore.Domain.Entities;

namespace SampleStore.Application.Common.Interfaces.Persistence;

public interface ICollectionRepository
{
    void Add(Collection collection);

    Collection? GetCollectionWithArticles(string name);
}