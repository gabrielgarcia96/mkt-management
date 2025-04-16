using Marketing.Domain.Models;
using MongoDB.Driver;

namespace Marketing.Infrastructure;

public class ConfigurationMongoDb
{
    private readonly IMongoDatabase _database;

    public ConfigurationMongoDb(string stringConnection, string databaseName)
    {
        var confgiuration = new MongoClient(stringConnection);
        _database = confgiuration.GetDatabase(databaseName);
    }

    public IMongoCollection<User> UserCollection => _database.GetCollection<User>("user");
    public IMongoCollection<Customer> CustomerCollection => _database.GetCollection<Customer>("customer");
}
