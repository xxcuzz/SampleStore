using SampleStore.Domain.Common.Models;
using SampleStore.Domain.ValueObjects;

namespace SampleStore.Domain.Entities;

public class Article : Entity<ArticleId>
{
    public string Name { get; private set; }
    public Price Price { get; private set; }
    
    public List<CollectionId>? CollectionIds { get; private set; }
    
    public CategoryId CategoryId { get; private set; }
    
    // TODO
    // public Material Material { get; private set; }
    // public bool IsBestseller { get; private set; }
    // public bool IsSoldOut { get; private set; }
    // public percentage articleDiscount
    
    // public string slug
    // public string tag (optional)
    
    private Article() { }
    
    private Article(ArticleId id,
        string name,
        Price price,
        List<CollectionId>? collectionIds,
        CategoryId categoryId) : base(id)
    {
        Id = id;
        Name = name;
        Price = price;
        CollectionIds = collectionIds;
        CategoryId = categoryId;
    }
    
    public static Article Create(string name,
        decimal originalPrice,
        List<CollectionId>? collectionIds,
        CategoryId categoryId,
        decimal? discountedPrice = null)
    {
        var price = Price.Create(originalPrice, discountedPrice);
        return new Article(ArticleId.CreateUnique(), name, price, collectionIds, categoryId);
    }
}
