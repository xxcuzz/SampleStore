using SampleStore.Domain.Common.Models;
using SampleStore.Domain.ValueObjects;

namespace SampleStore.Domain.Entities;

public class Article : Entity<ArticleId>
{
    public string Name { get; private set; }
    public Price Price { get; private set; }
    
    // TODO
    //public bool IsBestseller { get; private set; }
    //public bool IsSoldOut { get; private set; }
    //public percentage individualDiscount
    
    public List<CollectionId> CollectionIds { get; }
    
    private Article(ArticleId id, string name, Price price, List<CollectionId> collectionIds) : base(id)
    {
        Name = name;
        Price = price;
        CollectionIds = collectionIds;
    }

    public static Article Create(string name, Price price, List<CollectionId> collectionIds)
    {
        return new Article(ArticleId.CreateUnique(), name, price, collectionIds);
    }
    
    public static Article Create(string name, decimal originalPrice, decimal? discountedPrice, List<CollectionId> collectionIds)
    {
        var price = Price.Create(originalPrice, discountedPrice);
        return new Article(ArticleId.CreateUnique(), name, price, collectionIds);
    }
}