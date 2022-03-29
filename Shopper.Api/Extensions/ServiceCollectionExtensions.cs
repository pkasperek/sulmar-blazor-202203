using System.Text.Json;
using System.Text.Json.Serialization;
using Bogus;
using Microsoft.AspNetCore.Http.Json;
using Shopper.Api.Endpoints;
using Shopper.Domain.Models;
using Shopper.Domain.Repositories;
using Shopper.Infrastructure;
using Shopper.Infrastructure.Fakers;

namespace Shopper.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEndpointRouting(this IServiceCollection services)
    {
        services.AddTransient<IEndpointRouting, CustomersEndpoints>();
        services.AddTransient<IEndpointRouting, ProductsEndpoints>();

        return services;
    }
    
    public static IServiceCollection ConfigureJsonOptions(this IServiceCollection services)
        => services.Configure<JsonOptions>(options =>
        {
            options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.SerializerOptions.PropertyNameCaseInsensitive = true;
            options.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        });
    
    
    public static IServiceCollection AddFakeServices(this IServiceCollection services)
    {
        AddFakeProductsServices(services);
        AddFakeCustomerServices(services);

        return services;
    }

    private static void AddFakeProductsServices(this IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, FakeProductRepository>();
        services.AddSingleton<Faker<Product>, ProductFaker>();
    }

    private static void AddFakeCustomerServices(this IServiceCollection services)
    {
        services.AddSingleton<ICustomerRepository, FakeCustomerRepository>();
        services.AddSingleton<Faker<Customer>, CustomerFaker>();
    }
}
