using Marketing.Application.Interfaces;
using Marketing.Domain.Models;
using Marketing.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketing.Application.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;

        public LeadService(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<List<Lead>> GetAllAsync()
        {
            return await _leadRepository.GetAllAsync();
        }

        public async Task<Lead> GetByIdAsync(string id)
        {
            return await _leadRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Lead lead)
        {
            await _leadRepository.CreateAsync(lead);
        }

        public async Task UpdateAsync(string id, Lead lead)
        {
            await _leadRepository.UpdateAsync(id, lead);
        }

        public async Task DeleteAsync(string id)
        {
            await _leadRepository.DeleteAsync(id);
        }
    }
}
