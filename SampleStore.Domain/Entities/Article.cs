using SampleStore.Domain.ArticleType;
using SampleStore.Domain.Common.Models;
using SampleStore.Domain.ValueObjects;

namespace SampleStore.Domain.Entities;

public class Article : Entity<ArticleId>
{
    public string Name { get; private set; }
    public Price Price { get; private set; }
    public ArticleTypeEnum ArticleType { get; private set; }
    public List<CollectionId> CollectionIds { get; private set; }
    
    // TODO
    //public bool IsBestseller { get; private set; }
    //public bool IsSoldOut { get; private set; }
    //public percentage articleDiscount
    
    private Article() { }
    
    public Article(ArticleId id,
        string name,
        Price price,
        List<CollectionId> collectionIds,
        ArticleTypeEnum articleType) : base(id)
    {
        Id = id;
        Name = name;
        Price = price;
        CollectionIds = collectionIds;
        ArticleType = articleType;
    }
    
    public static Article Create(string name,
        decimal originalPrice,
        List<CollectionId> collectionIds,
        ArticleTypeEnum articleType,
        decimal? discountedPrice = null)
    {
        var price = Price.Create(originalPrice, discountedPrice);
        return new Article(ArticleId.CreateUnique(), name, price, collectionIds, articleType);
    }
}