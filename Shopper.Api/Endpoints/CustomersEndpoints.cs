using Shopper.Domain.Models;
using Shopper.Domain.Repositories;

namespace Shopper.Api.Endpoints;

public class CustomersEndpoints : IEndpointRouting 
{
    private readonly  ICustomerRepository customersRepository;

    public CustomersEndpoints(ICustomerRepository repository)
    {
        this.customersRepository = repository;
    }

    /// <inheritdoc />
    public void Register(WebApplication app)
    {
        app.MapGet("api/customers", GetCustomers).WithTags("Customers");

        app.MapGet("api/customers/{id:int}", GetCustomerById).WithTags("Customers");

        app.MapGet("api/customers/search", Search).WithTags("Customers");
    }
    
    private IResult GetCustomers()
    {
        return Results.Ok(customersRepository.GetAsync());
    }

    private IResult GetCustomerById(int id)
    {
        return Results.Ok(customersRepository.GetByIdAsync(id));
    }

    private async Task<IEnumerable<Customer>?> Search(string name)
    {
        return await customersRepository.GetByNameAsync(name);
    }
}