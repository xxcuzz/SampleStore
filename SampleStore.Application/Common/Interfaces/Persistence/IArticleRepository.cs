using SampleStore.Domain.ArticleType;
using SampleStore.Domain.Entities;

namespace SampleStore.Application.Common.Interfaces.Persistence;

public interface IArticleRepository
{
    Task AddAsync(Article article);
    
    Task<Article?> Async(string name);
    
    Task<IEnumerable<Article>> GetArticlesByTypeAsync(ArticleTypeEnum articleType);
}