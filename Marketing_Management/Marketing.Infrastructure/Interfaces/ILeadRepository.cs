using Marketing.Domain.Models;

namespace Marketing.Infrastructure.Interfaces;

public interface ILeadRepository
{
    Task<List<Lead>> GetAllAsync();
    Task<Lead> GetByIdAsync(string id);
    Task CreateAsync(Lead lead);
    Task UpdateAsync(string id, Lead lead);
    Task DeleteAsync(string id);
}
