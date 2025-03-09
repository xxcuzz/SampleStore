using SampleStore.Domain.Common.Models;
using SampleStore.Domain.ValueObjects;

namespace SampleStore.Domain.Entities;

public sealed class Collection : Entity<CollectionId>
{
    public string Name { get; private set; }
    public List<ArticleId>? ArticleIds { get; private set; }
    
    // TODO
    // collectionDiscount
    
    private Collection() { }
    
    public Collection(CollectionId collectionId, string name, List<ArticleId>? articleIds = null) : base(collectionId)
    {
        Id = collectionId;
        Name = name;
        ArticleIds = articleIds;
    }

    public static Collection Create(string name, List<ArticleId>?  articleIds = null)
    {
        return new Collection(CollectionId.CreateUnique(), name, articleIds);
    }
}