using Shopper.Domain.Models;

namespace Shopper.Domain.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>?> GetAsync(CancellationToken token = default);
    Task<IEnumerable<Customer>?> GetByNameAsync(string name, CancellationToken token = default);

    Task<Customer?> GetByIdAsync(int id);
}