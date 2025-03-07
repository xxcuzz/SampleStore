using SampleStore.Domain.Common.Models;

namespace SampleStore.Domain.ValueObjects;

public sealed class ArticleId : ValueObject
{
    public Guid Value { get; }

    private ArticleId(Guid value)
    {
        Value = value;
    }

    public static ArticleId CreateUnique() => new(Guid.NewGuid());

    public static ArticleId Create(Guid value) => new(value);
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}