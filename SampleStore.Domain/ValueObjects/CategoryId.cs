using SampleStore.Domain.Common.Models;

namespace SampleStore.Domain.ValueObjects;

public class CategoryId : ValueObject
{
    public Guid Value { get; private set; }
 
    private CategoryId(Guid value)
    {
        Value = value;
    }
    
    public static CategoryId CreateUnique() => new(Guid.NewGuid());

    public static CategoryId Create(Guid value) => new(value);
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}