using Marketing.Domain.Models;

namespace Marketing.Application.Interfaces;

public interface ICampaignService
{
    Task<List<Campaign>> GetAllAsync();
    Task<Campaign> GetByIdAsync(string id);
    Task CreateAsync(Campaign campaign);
    Task UpdateAsync(string id, Campaign campaign);
    Task DeleteAsync(string id);
}
