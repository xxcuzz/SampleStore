using SampleStore.Domain.Common.Models;

namespace SampleStore.Domain.ValueObjects;

public class Price : ValueObject
{
    public decimal OriginalPrice { get; private set; }
    public decimal? DiscountedPrice { get; private set; }

    private Price(decimal originalPrice, decimal? discountedPrice)
    {
        OriginalPrice = originalPrice;
        DiscountedPrice = discountedPrice ?? originalPrice;
    }
    
    public static Price Create(decimal originalPrice, decimal? discountedPrice = null) => new(originalPrice, discountedPrice);
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return OriginalPrice;
        yield return DiscountedPrice ?? OriginalPrice;
    }
}