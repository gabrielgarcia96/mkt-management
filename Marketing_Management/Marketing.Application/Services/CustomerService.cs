using Marketing.Application.Interfaces;
using Marketing.Domain.Models;
using Marketing.Infrastructure.Interfaces;
using Marketing.Infrastructure.Repository;

namespace Marketing.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<List<Customer>> GetAllCustomersAsync()
    {
       return _customerRepository.GetAllCustomerAsync();
    }

    public Task<Customer> GetCustomerNameAsync(string customerName)
    {
        return _customerRepository.GetCustomerAsync(customerName);
    }

    public Task RegisterCustomerAsync(Customer customer)
    {
        return _customerRepository.CreateCustomerAsync(customer);
    }

    public Task UpdateCustomerAsync(string customerName, Customer customer)
    {
        return _customerRepository.UpdateCustomer(customerName, customer);
    }
}
