using Marketing.Domain.Models;

namespace Marketing.Infrastructure.Interfaces;

public interface ICustomerRepository
{
    Task<Customer> GetCustomerAsync(string customerName);
    Task<List<Customer>> GetAllCustomerAsync();
    Task CreateCustomerAsync(Customer customer);
    Task UpdateCustomer(string customerCnpj, Customer customer);
    Task DeleteCustomerAsync(string customerCnpj);

    Task<Customer> GetCustomerCnpjAsync(string customerCnpj);
}
