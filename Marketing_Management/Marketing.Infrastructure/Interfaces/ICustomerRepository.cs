using Marketing.Domain.Models;

namespace Marketing.Infrastructure.Interfaces;

public interface ICustomerRepository
{
    Task<Customer> GetCustomerAsync(string customerName);
    Task<List<Customer>> GetAllCustomerAsync();
    Task CreateCustomerAsync(Customer customer);
    Task UpdateCustomer(string customerName, Customer customer);
    Task DeleteCustomerAsync(string customerName);
}
