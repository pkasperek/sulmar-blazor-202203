using Bogus;
using Microsoft.AspNetCore.Cors;
using Shopper.Domain.Models;
using Shopper.Infrastructure;
using Shopper.Infrastructure.Fakers;
using Shopper.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(
    o => o.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader().AllowAnyMethod())
);


builder.Services.AddSingleton<Faker<Product>, ProductFaker>();
builder.Services.AddSingleton<IProductRepository, FakeProductRepository>();

var app = builder.Build();

app.UseCors();

app.MapGet("/", () => "Hello World!");
app.MapGet("api/products", async (IProductRepository repository) => await repository.GetAsync());
app.MapGet("api/products/{id:int}", async(IProductRepository repository, int id) => await repository.GetByIdAsync(id));
app.MapGet("api/products/colors/{color}", async(IProductRepository repository, string color) => await repository.GetByColor(color));

app.Run();
