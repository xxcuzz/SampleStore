using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Domain.Entities;
using SampleStore.Domain.ValueObjects;

namespace SampleStore.Infrastructure.Persistence.EfCoreRepositories;

public class ArticleRepository : IArticleRepository
{
    public void Add(Article article)
    {
        // TODO
        return;
    }

    public Article? GetArticleByName(string name)
    {
        // TODO
        return Article.Create(
            name,
            Price.Create(10m),
            [CollectionId.CreateUnique()]);
        return null;
    }
}