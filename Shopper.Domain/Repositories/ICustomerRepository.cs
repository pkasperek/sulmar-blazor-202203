using Shopper.Domain.Models;

namespace Shopper.Domain.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAsync();
    Task<Customer> GetByIdAsync(int id);
    Task<IEnumerable<Customer>?> GetByNameAsync(string firstName, string lastName);
    Task<IEnumerable<Customer>?> GetByFirstNameAsync(string firstName);
    Task<IEnumerable<Customer>?> GetByLastNameAsync(string lastName);
    Task<IEnumerable<Customer>> GetByGenderAsync(GenderType gender);

    Task AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task RemoveAsync(int id);
    Task<bool> ExistsAsync(int id);
}