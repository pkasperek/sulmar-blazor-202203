using Shopper.Domain.Repositories;

namespace Shopper.Api.Endpoints;

public class ProductsEndpoints : IEndpointRouting 
{
    private readonly IProductRepository productsRepository;

    public ProductsEndpoints(IProductRepository repository)
    {
        this.productsRepository = repository;
    }

    /// <inheritdoc />
    public void Register(WebApplication app)
    {
        app.MapGet("api/products", GetProducts).WithTags("Products");
        
        app.MapGet("api/products/{id:int}", GetProductById).WithTags("Products");
    }
    
    private IResult GetProducts()
    {
        return Results.Ok(productsRepository.GetAsync());
    }

    private IResult GetProductById(int id)
    {
        return Results.Ok(productsRepository.GetByIdAsync(id));
    }

}