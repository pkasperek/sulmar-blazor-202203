using Bogus;
using Bogus.DataSets;
using Shopper.Domain.Extensions;
using Shopper.Domain.Models;
using Shopper.Domain.Repositories;

namespace Shopper.Infrastructure;

public class FakeCustomerRepository : ICustomerRepository
{
    private readonly IDictionary<int, Customer> customer;

    public FakeCustomerRepository(Faker<Customer> faker)
    {
        var list = faker.Generate(1000);

        customer = list.ToDictionary(p => p.Id);
    }


    public Task<IEnumerable<Customer>> GetByGenderAsync(GenderType gender)
    {
        var list = Enumerable.Where(customer.Values, p => p.Gender != null && p.Gender.Value == gender);
        return Task.FromResult(list);
    }

    public Task AddAsync(Customer customer)
    {
        var id = this.customer.Values.Max(p=>p.Id);

        customer.Id = ++id;

        this.customer.Add(customer.Id, customer);

        return Task.CompletedTask;
    }

    public Task<bool> ExistsAsync(int id)
    {
        return Task.FromResult(customer.ContainsKey(id));
    }

    public Task<IEnumerable<Customer>> GetAsync()
    {
        return Task.FromResult(customer.Values.AsEnumerable());
    }

    public Task<Customer> GetByIdAsync(int id)
    {
        return this.customer.TryGetValue(id, out var customer) ? Task.FromResult(customer) : Task.FromResult<Customer>(null);
    }

    public Task<IEnumerable<Customer>?> GetByNameAsync(string name)
    {
        var list = customer.Values?.Where(p => p.Name().Contains(name, StringComparison.OrdinalIgnoreCase));
        
        return Task.FromResult(list);    }

    public Task<IEnumerable<Customer>?> GetByFirstNameAsync(string firstName)
    {
        var list = customer.Values?.Where(p => p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(list);
    }

    public Task<IEnumerable<Customer>?> GetByLastNameAsync(string lastName)
    {
        var list = customer.Values?.Where(p => p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(list);
    }

    public Task RemoveAsync(int id)
    {
        customer.Remove(id);
        return Task.CompletedTask;
    }

    public async Task UpdateAsync(Customer customer)
    {
        await RemoveAsync(customer.Id);
        this.customer.Add(customer.Id, customer);
    }
}