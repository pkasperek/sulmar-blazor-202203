using System.Net.Http.Json;
using Shopper.Domain.Models;

namespace Shopper.BlazorWasm.Services;

public class ProductService : IProductService
{
    private readonly HttpClient client;

    public ProductService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<IEnumerable<Product>?> GetAsync()
    {
        return await client.GetFromJsonAsync<IEnumerable<Product>>("api/products");
    }
    
    public async Task<IEnumerable<Product>?> GetByIdAsync(int id)
    {
        return await client.GetFromJsonAsync<IEnumerable<Product>>("api/products/{id}");
    }
    
}