using SampleStore.Domain.Common.Models;

namespace SampleStore.Domain.ValueObjects;

public sealed class CollectionId : ValueObject
{
    public Guid Value { get; }

    private CollectionId(Guid value)
    {
        Value = value;
    }

    public static CollectionId CreateUnique() => new(Guid.NewGuid());
    
    public static CollectionId Create(Guid value) => new(value);
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}