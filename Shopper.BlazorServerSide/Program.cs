using Bogus;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Shopper.BlazorServerSide.Data;
using Shopper.Domain.Models;
using Shopper.Infrastructure;
using Shopper.Infrastructure.Fakers;
using Shopper.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<Faker<Product>, ProductFaker>();
builder.Services.AddSingleton<IProductRepository, FakeProductRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
