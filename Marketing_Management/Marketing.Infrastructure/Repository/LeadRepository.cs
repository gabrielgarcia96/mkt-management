using Marketing.Domain.Models;
using Marketing.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Marketing.Infrastructure.Repository
{
    public class LeadRepository : ILeadRepository
    {
        private readonly ConfigurationMongoDb _configmongoDb;
        private readonly IConfiguration _configuration;

        public LeadRepository(ConfigurationMongoDb confimongoDb, IConfiguration configuration)
        {
            _configmongoDb = confimongoDb;
            _configuration = configuration;
        }

        public async Task CreateAsync(Lead lead)
            => await _configmongoDb.LeadCollection.InsertOneAsync(lead);
        
        public async Task DeleteAsync(string id)
            => await _configmongoDb.LeadCollection.DeleteOneAsync(l => l.Id == id);

        public async Task<List<Lead>> GetAllAsync()
         => await _configmongoDb.LeadCollection.Find(_ => true).ToListAsync();

        public async Task<Lead> GetByIdAsync(string id)
            => await _configmongoDb.LeadCollection.Find(l => l.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(string id, Lead lead)
         => await _configmongoDb.LeadCollection.ReplaceOneAsync(l => l.Id == id, lead);
    }
}
