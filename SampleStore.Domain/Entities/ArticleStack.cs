using SampleStore.Domain.ValueObjects;

namespace SampleStore.Domain.Entities;

// TODO
public class ArticleStack
{
    public string Name { get; private set; }
    public List<ArticleId> ArticleIds { get; private set; }
    
    public Price TotalPrice { get; private set; }
}