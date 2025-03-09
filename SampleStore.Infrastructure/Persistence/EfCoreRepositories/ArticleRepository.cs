using Microsoft.EntityFrameworkCore;

using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Domain.ArticleType;
using SampleStore.Domain.Entities;

namespace SampleStore.Infrastructure.Persistence.EfCoreRepositories;

public class ArticleRepository : IArticleRepository
{
    private readonly SampleStoreDbContext _dbContext;

    public ArticleRepository(SampleStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Article article)
    {
        await _dbContext.Articles.AddAsync(article);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Article?> Async(string name)
    {
        var article = await _dbContext.Articles.FirstOrDefaultAsync(x => x.Name == name);
        return article;
    }

    public async Task<IEnumerable<Article>> GetArticlesByTypeAsync(ArticleTypeEnum articleType)
    {
        var articles = await _dbContext.Articles.Where(x => x.ArticleType == articleType).ToListAsync();
        return articles;
    }
}