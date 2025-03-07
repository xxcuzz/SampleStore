using SampleStore.Domain.Entities;

namespace SampleStore.Application.Common.Interfaces.Persistence;

public interface IArticleRepository
{
    void Add(Article article);
    
    Article? GetArticleByName(string name);
}