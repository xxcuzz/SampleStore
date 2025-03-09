using SampleStore.Domain.Entities;
using SampleStore.Domain.ValueObjects;

namespace SampleStore.Infrastructure.Persistence.Entities;

public class ArticleCollection
{
    public ArticleId ArticleId { get; set; }
    public CollectionId CollectionId { get; set; }

    public required Article Article { get; set; }
    public required Collection Collection{ get; set; }
}