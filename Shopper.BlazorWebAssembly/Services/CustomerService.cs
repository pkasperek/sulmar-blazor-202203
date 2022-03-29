using System.Net.Http.Json;
using Shopper.Domain.Models;
using Shopper.Domain.Services;

namespace Shopper.BlazorWebAssembly.Services;

public class CustomerService : ICustomerService
{
    private readonly HttpClient client;

    public CustomerService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<IEnumerable<Customer>?> GetAsync(CancellationToken token = default)
    {
        return await client.GetFromJsonAsync<IEnumerable<Customer>>("api/customers", token);
    }

    public async Task<IEnumerable<Customer>?> GetByLastNameAsync(string lastName, CancellationToken token = default)
    {
        return await client.GetFromJsonAsync<IEnumerable<Customer>>($"api/customers/lastname/{lastName}", token);
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await client.GetFromJsonAsync<Customer>($"api/customers/{id}");
    }
}