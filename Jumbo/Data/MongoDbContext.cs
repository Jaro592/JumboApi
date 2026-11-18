using MongoDB.Driver;

namespace Jumbo.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        // Komen uit de .env in de root van de repo (ingeladen in Program.cs)
        var connectionString = configuration["MONGODB_CONNECTION_STRING"];
        var databaseName = configuration["MONGODB_DATABASE_NAME"];

        var client = new MongoClient(connectionString);

        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName) => _database.GetCollection<T>(collectionName);
}


// using MongoDB.Driver;
// using Microsoft.Extensions.Configuration;
// public class MongoDbContext
// {
//     private readonly IMongoDatabase _database;

//     public MongoDbContext(IConfiguration configuration)
//     {
//         var connectionString = configuration["MongoDb:ConnectionString"];
//         var databaseName = configuration["MongoDb:DatabaseName"];

//         var client = new MongoClient(connectionString);

//         _database = client.GetDatabase(databaseName);
//     }

//     public IMongoCollection<T> GetCollection<T>(string collectionName) => _database.GetCollection<T>(collectionName);

// }