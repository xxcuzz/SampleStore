using System.Data;

namespace SampleStore.Infrastructure.Persistence.Dapper;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync(CancellationToken token = default);
}