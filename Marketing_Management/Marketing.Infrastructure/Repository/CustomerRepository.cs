using Marketing.Domain.Models;
using Marketing.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Marketing.Infrastructure.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly ConfigurationMongoDb _configmongoDb;
    private readonly IConfiguration _configuration;

    public CustomerRepository(ConfigurationMongoDb confimongoDb,  IConfiguration configuration)
    {
        _configmongoDb = confimongoDb;
        _configuration = configuration;
    }

    public Task CreateCustomerAsync(Customer customer)
    {
        return _configmongoDb.CustomerCollection.InsertOneAsync(customer);
    }

    public  Task<List<Customer>> GetAllCustomerAsync()
    {
        return _configmongoDb.CustomerCollection.Find(c => true)
            .Project(c => new Customer
            {
                SocialReason = c.SocialReason,
                Name = c.Name,
                Cnpj = c.Cnpj,
                City = c.City,
                Address = c.Address,
                PostalCode = c.PostalCode,
                TypeContract = c.TypeContract,
                ContractStartDate = c.ContractStartDate,
                ContractEndDate = c.ContractEndDate,
                ContractFile = c.ContractFile,
                Status = c.Status,

            }).ToListAsync();
    }

    public Task<Customer> GetCustomerAsync(string customerName)
    {
        return _configmongoDb.CustomerCollection.Find(c => c.Name == customerName)
            .FirstOrDefaultAsync();
    }

    public Task<Customer> GetCustomerCnpjAsync(string customerCnpj)
    {
        return _configmongoDb.CustomerCollection.Find(c => c.Cnpj == customerCnpj)
            .FirstOrDefaultAsync();
    }

    public async Task UpdateCustomer(string customerCnpj, Customer customer)
    {
        var filter = Builders<Customer>.Filter.Eq(c => c.Cnpj, customerCnpj);
        var update = Builders<Customer>.Update
             .Set(c => c.SocialReason, customer.SocialReason)
             .Set(c => c.Name, customer.Name)
             .Set(c => c.Email, customer.Email)
             .Set(c => c.PostalCode, customer.PostalCode)
             .Set(c => c.Address, customer.Address)
             .Set(c => c.City, customer.City)
             .Set(c => c.Region, customer.Region)
             .Set(c => c.TypeContract, customer.TypeContract)
             .Set(c => c.ContractStartDate, customer.ContractStartDate)
             .Set(c  => c.ContractEndDate, customer.ContractEndDate)
             .Set(c => c.ContractFile, customer.ContractFile)
             .Set(c => c.Status, customer.Status);

        await _configmongoDb.CustomerCollection.UpdateOneAsync(filter, update);
    }

    public async Task DeleteCustomerAsync(string customerCnpj)
    {
        var filter = Builders<Customer>.Filter.Eq(c => c.Cnpj, customerCnpj);
        await _configmongoDb.CustomerCollection.DeleteOneAsync(filter);
    }
}
