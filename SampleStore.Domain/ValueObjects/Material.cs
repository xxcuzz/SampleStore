using SampleStore.Domain.Common.Models;

namespace SampleStore.Domain.ValueObjects;

// TODO
public class Material : ValueObject
{
    public string ImageUrl { get; private set; }
    
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return ImageUrl;
    }
}