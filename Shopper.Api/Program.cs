
using Bogus;
using Microsoft.OpenApi.Models;
using Shopper.Domain.Models;
using Shopper.Domain.Repositories;
using Shopper.Infrastructure;
using Shopper.Infrastructure.Fakers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "Api", Version = "v1"});
});

builder.Services.AddSingleton<IProductRepository, FakeProductRepository>();
builder.Services.AddSingleton<Faker<Product>, ProductFaker>();

builder.Services.AddSingleton<ICustomerRepository, FakeCustomerRepository>();
builder.Services.AddSingleton<Faker<Customer>, CustomerFaker>();

builder.Se

builder.Services.AddCors(
    policy => policy.AddDefaultPolicy(
    options => options.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
    .AllowAnyHeader()
    .AllowAnyMethod()));


var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
}


app.MapGet("/", () => "Hello World!");

// Minimal API (od .NET 6)

// GET api/products
app.MapGet("api/products", async 
    (IProductRepository productRepository) => await productRepository.GetAsync());

// GET api/products/{id}
app.MapGet("api/products/{id:int}", async
    (IProductRepository productRepository, int id) => await productRepository.GetByIdAsync(id));

// GET api/customers
app.MapGet("api/customers", async 
    (ICustomerRepository customerRepository) => await customerRepository.GetAsync());

// GET api/customers/{id}
app.MapGet("api/customers/{id:int}", async
    (ICustomerRepository customerRepository, int id) => await customerRepository.GetByIdAsync(id));

app.MapGet("api/customers/search", async
    (ICustomerRepository customerRepository, string name) => await customerRepository.GetByNameAsync(name));


app.Run();
