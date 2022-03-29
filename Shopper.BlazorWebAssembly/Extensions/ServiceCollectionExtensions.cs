using Shopper.BlazorWebAssembly.Services;
using Shopper.Domain.Services;

namespace Shopper.BlazorWebAssembly.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFakeServices(this IServiceCollection services)
    {
        AddFakeProductsServices(services);
        AddFakeCustomerServices(services);

        return services;
    }

    private static void AddFakeProductsServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }

    private static void AddFakeCustomerServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
    }
    
}
