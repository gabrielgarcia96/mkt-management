using Marketing.Application.Interfaces;
using Marketing.Domain.Models;
using Marketing.Infrastructure.Interfaces;
using Marketing.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketing.Application.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;

        public CampaignService(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<List<Campaign>> GetAllAsync()
        {
            return await _campaignRepository.GetAllAsync();
        }

        public async Task<Campaign> GetByIdAsync(string id)
        {
          return await _campaignRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Campaign campaign)
        {
            await _campaignRepository.CreateAsync(campaign);
        }
        public async Task UpdateAsync(string id, Campaign campaign)
        {
            await _campaignRepository.UpdateAsync(id, campaign);
        }

        public async Task DeleteAsync(string id)
        {
            await _campaignRepository.DeleteAsync(id);
        }
    }
}
