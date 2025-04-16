using Marketing.Domain.Models;
using Marketing.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Marketing.Infrastructure.Repository;
public class AccountRepository : IAccountRepository
{
    private readonly ConfigurationMongoDb _configmongoDb;
    private readonly IConfiguration _configuration;

    public AccountRepository(ConfigurationMongoDb configmongoDb, IConfiguration configuration)
    {
        _configmongoDb = configmongoDb;
        _configuration = configuration;
    }

    public Task CreateUserAsync(User user)
    {
       return _configmongoDb.UserCollection.InsertOneAsync(user);
    }

    public Task<User> GetEmailAsync(string email)
    {
        return _configmongoDb.UserCollection.Find
            (e => e.Email == email).FirstOrDefaultAsync();
    }
    public  Task<List<User>> GetAllUserAsync()
    {
        return _configmongoDb.UserCollection.Find(u => true)
            .Project(u => new User
            { 
             Username = u.Username,
             Email = u.Email,
             Role = u.Role,
            }).ToListAsync();
    }

    public Task<User> GetUserAsync(string username)
    {
        return _configmongoDb.UserCollection.Find(u => u.Username == username).FirstOrDefaultAsync();
    }

    public async Task UpdateUser(string username, User user)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Username, username);
        var update = Builders<User>.Update
             .Set(u => u.Username, user.Username)
             .Set(u => u.Email, user.Email)
             .Set(u => u.Password, user.Password)
                .Set(u => u.Role, user.Role);

        await _configmongoDb.UserCollection.UpdateOneAsync(filter, update);
    }

    public Task DeleteUserAsync(string name)
    {
        return _configmongoDb.UserCollection.DeleteOneAsync(name);
    }
}
