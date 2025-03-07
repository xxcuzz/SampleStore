using SampleStore.Domain.Common.Models;
using SampleStore.Domain.ValueObjects;

namespace SampleStore.Domain.Entities;

public sealed class Collection : Entity<CollectionId>
{
    public string Name { get; }
    public List<ArticleId>? ArticleIds { get; }
    
    // TODO
    // collectionDiscount
    
    private Collection(CollectionId collectionId, string name, List<ArticleId>? articleIds = null) : base(collectionId)
    {
        Name = name;
        ArticleIds = articleIds;
    }

    public static Collection Create(string name, List<ArticleId>?  articleIds = null)
    {
        return new Collection(CollectionId.CreateUnique(), name, articleIds);
    }
}