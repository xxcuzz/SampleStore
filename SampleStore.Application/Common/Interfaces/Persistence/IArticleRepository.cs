using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Entities;

namespace SampleStore.Application.Common.Interfaces.Persistence;

public interface IArticleRepository
{
    Task AddAsync(Article article);
    
    Task<ArticleDtoSlim?> GetArticleByNameAsync(string name);
    
    Task<List<ArticleDtoSlim>> GetArticlesByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken);
    
    Task<List<ArticleDtoSlim>> GetArticlesByCollectionIdAsync(Guid collectionId, CancellationToken cancellationToken);
}
