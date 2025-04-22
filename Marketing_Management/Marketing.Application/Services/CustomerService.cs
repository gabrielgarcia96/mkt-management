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

    public Task<Customer> GetCustomerCnpjAsync(string customerCnpj)
    {
        return _customerRepository.GetCustomerCnpjAsync(customerCnpj);
    }

    public async Task RegisterCustomerAsync(Customer customer)
    {
        var existCustomer = await _customerRepository.GetCustomerCnpjAsync(customer.Cnpj);

        if (existCustomer != null)
        {
            Console.WriteLine("Username already exists!");
            return;
        }

        customer.ContractStartDate = customer.ContractStartDate.ToUniversalTime();
        customer.ContractEndDate = customer.ContractEndDate.ToUniversalTime();


        var newCustomer = new Customer
        {
            Name = customer.Name,
            Email = customer.Email,
            Cnpj = customer.Cnpj,
            PostalCode = customer.PostalCode,
            Address = customer.Address,
            City = customer.City,
            Region = customer.Region,
            TypeContract = customer.TypeContract,
            ContractStartDate = customer.ContractStartDate,
            ContractEndDate = customer.ContractEndDate,
            Status = customer.Status
        };

        await _customerRepository.CreateCustomerAsync(newCustomer);
    }

    public Task UpdateCustomerAsync(string customerCnpj, Customer customer)
    {
        return _customerRepository.UpdateCustomer(customerCnpj, customer);
    }


    public Task DeleteCustomerAsync(string customerCnpj)
    {
        return _customerRepository.DeleteCustomerAsync(customerCnpj);
    }
}
