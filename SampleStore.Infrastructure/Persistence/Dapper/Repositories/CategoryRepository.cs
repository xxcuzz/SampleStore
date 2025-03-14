using Dapper;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Application.Models.DTO;

namespace SampleStore.Infrastructure.Persistence.Dapper.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IDbConnectionFactory _db;

    public CategoryRepository(IDbConnectionFactory db)
    {
        _db = db;
    }

    public async Task<List<CategoryDtoSlim>> GetCategoriesAsync(CancellationToken cancellationToken)
    {
        using var connection = await _db.CreateConnectionAsync(cancellationToken);

        var result = await connection.QueryAsync<CategoryDtoSlim>(
            """
            SELECT category_id AS Id, name AS Name, parent_category_id AS ParentId
                   FROM categories
            """);
        
        return result.ToList();
    }
}
