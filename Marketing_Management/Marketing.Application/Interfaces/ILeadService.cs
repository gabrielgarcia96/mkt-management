using Marketing.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketing.Application.Interfaces
{
    public interface ILeadService
    {
        Task<List<Lead>> GetAllAsync();
        Task<Lead> GetByIdAsync(string id);
        Task CreateAsync(Lead lead);
        Task UpdateAsync(string id, Lead lead);
        Task DeleteAsync(string id);
    }
}
