using Marketing.Domain.Models;

namespace Marketing.Application.Interfaces;

public interface ICustomerService
{
    Task RegisterCustomerAsync(Customer customer);
    Task<Customer> GetCustomerNameAsync(string customerName);
    Task<List<Customer>> GetAllCustomersAsync();
    Task UpdateCustomerAsync(string customerName, Customer customer);
    Task<Customer> GetCustomerCnpjAsync(string customerCnpj);
    Task DeleteCustomerAsync(string customerCnpj);

}
