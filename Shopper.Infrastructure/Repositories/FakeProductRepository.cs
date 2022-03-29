using Bogus;
using Shopper.Domain.Models;

namespace Shopper.Infrastructure.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        private readonly IDictionary<int, Product> products;

        public FakeProductRepository(Faker<Product> faker)
        {
            var list = faker.Generate(100);
            products = list.ToDictionary(p => p.Id);
        }

        public Task AddAsync(Product product)
        {
            var id = products.Values.Max(p=>p.Id);

            product.Id = ++id;

            products.Add(product.Id, product);

            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(int id)
        {
            return Task.FromResult(products.ContainsKey(id));
        }

        public Task<IEnumerable<Product>> GetByColor(string color)
        {
            var list = products.Values.Where(p => p.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(list);
        }

        public Task<IEnumerable<Product>> GetAsync()
        {
            return Task.FromResult(products.Values.AsEnumerable());
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            return products.TryGetValue(id, out var product) ? Task.FromResult(product) : Task.FromResult<Product>(default);
        }

        public Task RemoveAsync(int id)
        {
            products.Remove(id);
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Product product)
        {
            await RemoveAsync(product.Id);
            products.Add(product.Id, product);
        }
    }
}