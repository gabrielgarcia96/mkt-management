using Marketing.Domain.Models;
using Marketing.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Marketing.Infrastructure.Repository;

public class CampaignRepository : ICampaignRepository
{
    private readonly ConfigurationMongoDb _configmongoDb;
    private readonly IConfiguration _configuration;

    public CampaignRepository(ConfigurationMongoDb confimongoDb, IConfiguration configuration)
    {
        _configmongoDb = confimongoDb;
        _configuration = configuration;
    }

    public async Task CreateAsync(Campaign campaign)
        => await _configmongoDb.CampaignCollection.InsertOneAsync(campaign);
    

    public async Task DeleteAsync(string id)
    => await _configmongoDb.CampaignCollection.DeleteOneAsync(c => c.Id == id);

    public async Task<List<Campaign>> GetAllAsync()
    => await _configmongoDb.CampaignCollection.Find(_ => true).ToListAsync();

    public async Task<Campaign> GetByIdAsync(string id)
     => await _configmongoDb.CampaignCollection.Find(c => c.Id == id).FirstOrDefaultAsync();

    public async Task UpdateAsync(string id, Campaign campaign)
    => await _configmongoDb.CampaignCollection.ReplaceOneAsync(c => c.Id == id, campaign);
}
