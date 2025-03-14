using Dapper;
using SampleStore.Application.Common.Interfaces.Persistence;
using SampleStore.Application.Models.DTO;
using SampleStore.Domain.Entities;

namespace SampleStore.Infrastructure.Persistence.Dapper.Repositories;

public class CollectionRepository : ICollectionRepository
{
    private readonly IDbConnectionFactory _db;

    public CollectionRepository(IDbConnectionFactory db)
    {
        _db = db;
    }

    public Task AddAsync(Collection collection)
    {
        throw new NotImplementedException();
    }
    
    public async Task<List<CollectionDtoSlim>> GetCollectionsAsync(CancellationToken cancellationToken = default)
    {
        using var connection = await _db.CreateConnectionAsync(cancellationToken);

        var collections = await connection.QueryAsync<CollectionDtoSlim>(
            """
            SELECT collection_id AS Id, name AS Name FROM collections
            """);
        
        return collections.ToList();
    }
}
