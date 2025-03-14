using Dapper;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Entities;

namespace SampleStore.Infrastructure.Persistence.Dapper.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly IDbConnectionFactory _db;

    public ArticleRepository(IDbConnectionFactory db)
    {
        _db = db;
    }

    // TODO
    public async Task AddAsync(Article article)
    {
        throw new NotImplementedException();
        // using var connection = await _db.CreateConnectionAsync();
        // using var transaction = connection.BeginTransaction();
        // try
        // {
        //     await connection.ExecuteAsync(
        //         """
        //         INSERT INTO Articles (id ,name, original_price)
        //         VALUES (@ArticleId, @Name, @Price)
        //         """, article);
        //     
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e);
        //     throw;
        //}
    }

    public async Task<ArticleDtoSlim?> GetArticleByNameAsync(string name)
    {
        throw new NotImplementedException();

        // using var connection = await _db.CreateConnectionAsync();
        // var result = await connection.QuerySingleOrDefaultAsync<Article>(
        //     """
        //     SELECT * FROM Articles
        //     WHERE Name = @name
        //     """, name);
        //
        // return result;
    }
    
    public async Task<List<ArticleDtoSlim>> GetArticlesByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        using var connection = await _db.CreateConnectionAsync(cancellationToken);

        var articles = (await connection.QueryAsync<ArticleDtoSlim>(
            """
            SELECT article_id AS Id, name AS Name, price as OriginalPrice
            FROM articles
            WHERE category_id IN
                  (SELECT category_id
                   FROM categories c
                   WHERE c.parent_category_id = @id
                     OR c.category_id = @id);
            """, new { id = categoryId })).ToList();

        return articles;
    }

    public async Task<List<ArticleDtoSlim>> GetArticlesByCollectionIdAsync(Guid collectionId,
        CancellationToken cancellationToken)
    {
        using var connection = await _db.CreateConnectionAsync(cancellationToken);
        
        var articles = (await connection.QueryAsync<ArticleDtoSlim>(
            """
            SELECT articles.article_id AS Id, name AS Name, price as OriginalPrice
            FROM articles
            LEFT JOIN article_collection ON articles.article_id = article_collection.article_id
            WHERE article_collection.collection_id = @id
            """, new { id = collectionId })).ToList();
        
        return articles;
    }
}
