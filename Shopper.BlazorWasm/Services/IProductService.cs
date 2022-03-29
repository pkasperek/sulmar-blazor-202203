using Shopper.Domain.Models;

namespace Shopper.BlazorWasm.Services;

public interface IProductService
{
    Task<IEnumerable<Product>?> GetAsync();
    Task<IEnumerable<Product>?> GetByIdAsync(int id);
}