using Marketing.Application.Interfaces;
using Marketing.Domain.Enums;
using Marketing.Domain.Models;

namespace Marketing.Application.Services;

public class ImportService
{
    private readonly ILeadService _leadService;

    public ImportService(ILeadService leadService)
    {
        _leadService = leadService;
    }

    public async Task ImportLeads(string data)
    {
        var lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            var parts = line.Split(';');
            if (parts.Length == 2)
            {
                var lead = new Lead
                {
                    FullName = parts[0].Trim(),
                    Email = parts[1].Trim(),
                    Status = Status.potential,
                    CreatedAt = DateTime.UtcNow.AddHours(-3)
                };

                await _leadService.CreateAsync(lead);
            }
        }
    }
}
