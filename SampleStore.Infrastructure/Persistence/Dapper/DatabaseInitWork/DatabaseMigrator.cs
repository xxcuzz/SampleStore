using DbUp;

namespace SampleStore.Infrastructure.Persistence.Dapper.DatabaseInitWork;

public class DatabaseMigrator
{
    private readonly string _connectionString;
    public DatabaseMigrator(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public async Task InitializeAsync()
    {
        EnsureDatabase.For.PostgresqlDatabase(_connectionString);
        
        var upgrader = DeployChanges.To.PostgresqlDatabase(_connectionString)
            .WithScriptsEmbeddedInAssembly(typeof(NpgSqlConnectionFactory).Assembly)
            .LogScriptOutput()
            .Build();

        if (upgrader.IsUpgradeRequired())
        {
            var result = upgrader.PerformUpgrade();
            
            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                Console.ReadLine();
                return;
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
        }
    }
}
