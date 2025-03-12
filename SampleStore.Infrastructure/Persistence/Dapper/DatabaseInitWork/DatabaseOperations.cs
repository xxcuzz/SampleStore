using System.Data;
using Dapper;
using Npgsql;

namespace SampleStore.Infrastructure.Persistence.Dapper.DatabaseInitWork;

/// <summary>
/// A class for clearing and seeding the database.
/// </summary>
public class DatabaseOperations
{
    private readonly string _connectionString;

    public DatabaseOperations(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void ClearDatabase()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        connection.Execute("TRUNCATE article_collection, articles, collections, categories CASCADE;");
    }
    
    public void SeedDatabase()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        
        if (!IsDatabaseEmpty(connection))
        {
            return;
        };
        var transaction = connection.BeginTransaction();
        try
        {
            SeedDatabase(connection, transaction);
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
        }
    }

    private bool IsDatabaseEmpty(IDbConnection connection)
    {
        var tableNames = connection.Query<string>(
            """
            SELECT table_name 
            FROM information_schema.tables 
            WHERE table_schema = 'public'
            AND table_name != 'schemaversions'
            """);
        
        foreach (var tableName in tableNames)
        {
            var count = connection.ExecuteScalar<int>($"SELECT COUNT(1) FROM \"{tableName}\"");

            if (count > 0)
            {
                return false;
            }
        }
        
        return true;
    }

    private void SeedDatabase(IDbConnection connection, IDbTransaction transaction)
    {
        var categories = new[]
        {
            new { Id = Guid.NewGuid(), Name = "Outerwear", ParentCategoryId = (Guid?)null },
            new { Id = Guid.NewGuid(), Name = "Jewelry", ParentCategoryId = (Guid?)null },
            new { Id = Guid.NewGuid(), Name = "Hyper Items", ParentCategoryId = (Guid?)null },
            new { Id = Guid.NewGuid(), Name = "Gifts", ParentCategoryId = (Guid?)null },
        }.ToList();

        categories.AddRange([
            new { Id = Guid.NewGuid(), Name = "Glasses", ParentCategoryId = (Guid?)categories[0].Id },
            new { Id = Guid.NewGuid(), Name = "Masks", ParentCategoryId = (Guid?)categories[0].Id },
            new { Id = Guid.NewGuid(), Name = "Tops", ParentCategoryId = (Guid?)categories[0].Id },
            new { Id = Guid.NewGuid(), Name = "Rings", ParentCategoryId = (Guid?)categories[1].Id },
            new { Id = Guid.NewGuid(), Name = "Ear Cuffs", ParentCategoryId = (Guid?)categories[1].Id },
            new { Id = Guid.NewGuid(), Name = "Chokers And Chains", ParentCategoryId = (Guid?)categories[1].Id },
        ]);
        
        foreach (var category in categories)
        {
            connection.Execute(
                """
                INSERT INTO categories (category_id, name, parent_category_id)
                VALUES (@Id, @Name, @ParentCategoryId);
                """, category, transaction);
        }

        var articles = new[]
        {
            // Chains
            new { Id = Guid.NewGuid(), Name = "Neo Cipher Necklace", Price = 175m, CategoryId = categories[^1].Id },
            new { Id = Guid.NewGuid(), Name = "Trisector Chain", Price = 220m, CategoryId = categories[^1].Id },
            new { Id = Guid.NewGuid(), Name = "Alienus Epitome Choker", Price = 195m, CategoryId = categories[^1].Id  },
            new { Id = Guid.NewGuid(), Name = "Mercurial Rhizome Choker", Price = 255m, CategoryId = categories[^1].Id  },
            
            // Rings
            new { Id = Guid.NewGuid(), Name = "Neo Cipher Earrings", Price = 155m, CategoryId = categories[^2].Id },
            new { Id = Guid.NewGuid(), Name = "Fluidity Ear Cuff", Price = 125m, CategoryId = categories[^2].Id },
            new { Id = Guid.NewGuid(), Name = "Tribal Ring", Price = 125m, CategoryId = categories[^3].Id },
            new { Id = Guid.NewGuid(), Name = "Memoria Connexa Ring", Price = 125m, CategoryId = categories[^3].Id },
            new { Id = Guid.NewGuid(), Name = "Perceptio Ring", Price = 125m, CategoryId = categories[^3].Id },
            new { Id = Guid.NewGuid(), Name = "Arena Ring", Price = 125m, CategoryId = categories[^3].Id },
            
            // Tops
            new { Id = Guid.NewGuid(), Name = "Neo Apotheosis Top", Price = 795m, CategoryId = categories[^4].Id },
            
            //Masks
            new { Id = Guid.NewGuid(), Name = "Extrarius Mask", Price = 245m, CategoryId = categories[^5].Id },

            // Glasses
            new { Id = Guid.NewGuid(), Name = "Dystopian Verge Glasses", Price = 795m, CategoryId = categories[^6].Id },
            new { Id = Guid.NewGuid(), Name = "Void Glasses", Price = 225m, CategoryId = categories[^6].Id },
            
            // Gift cards
            new { Id = Guid.NewGuid(), Name = "Gift Card 150", Price = 150m, CategoryId = categories[3].Id },
            new { Id = Guid.NewGuid(), Name = "Gift Card 250", Price = 250m, CategoryId = categories[3].Id },
            
            // Outerwear!
            new { Id = Guid.NewGuid(), Name = "Transcendence Sword", Price = 2995m, CategoryId = categories[2].Id },
            new { Id = Guid.NewGuid(), Name = "Exo Enigma Headband", Price = 275m, CategoryId = categories[2].Id },
        };

        foreach (var article in articles)
        {
            connection.Execute(
                """
                INSERT INTO articles (article_id, name, price, category_id)
                VALUES (@Id, @Name, @Price, @CategoryId);
                """, article, transaction);
        }

        var collections = new[]
        {
            new { Id = Guid.NewGuid(), Name = "Bestsellers", ReleaseDate = (DateTime?)null },
            new { Id = Guid.NewGuid(), Name = "SS25 I Am Human", ReleaseDate = (DateTime?)new DateTime(2025,1,3) },
            new { Id = Guid.NewGuid(), Name = "Exclusive Deals", ReleaseDate = (DateTime?)null },
            new { Id = Guid.NewGuid(), Name = "Archived Collections", ReleaseDate = (DateTime?)null },
        };

        foreach (var collection in collections)
        {
            connection.Execute(
                """
                INSERT INTO collections (collection_id, name, release_date)
                VALUES (@Id, @Name, @ReleaseDate);
                """, collection, transaction);
        }

        var articleCollections = new[]
        {
            new { ArticleId = articles[0].Id, CollectionId = collections[1].Id },
            new { ArticleId = articles[4].Id, CollectionId = collections[1].Id },
            new { ArticleId = articles[7].Id, CollectionId = collections[1].Id },
            new { ArticleId = articles[12].Id, CollectionId = collections[1].Id },
            new { ArticleId = articles[13].Id, CollectionId = collections[1].Id },
            new { ArticleId = articles[15].Id, CollectionId = collections[1].Id },
        };

        foreach (var ac in articleCollections)
        {
            connection.Execute(
                """
                INSERT INTO article_collection (article_id, collection_id)
                VALUES (@ArticleId, @CollectionId);
                """, ac, transaction);
        }
    }
}
