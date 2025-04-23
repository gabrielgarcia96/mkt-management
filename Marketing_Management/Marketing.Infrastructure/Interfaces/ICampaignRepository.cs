using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing.Domain.Models;

namespace Marketing.Infrastructure.Interfaces
{
    public interface ICampaignRepository
    {
        Task<List<Campaign>> GetAllAsync();
        Task<Campaign> GetByIdAsync(string id);
        Task CreateAsync(Campaign campaign);
        Task UpdateAsync(string id, Campaign campaign);
        Task DeleteAsync(string id);
    }
}
