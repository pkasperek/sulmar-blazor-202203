using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serilog;
using Shopper.BlazorWebAssembly;
using Shopper.BlazorWebAssembly.Services;
using Shopper.Domain.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });

builder.Services.AddScoped<IProductService, ProductService>();


Log.Logger = new LoggerConfiguration()
    .WriteTo.BrowserHttp($"https://localhost:5001/ingest")
    .CreateLogger();

builder.Services.AddScoped<Serilog.ILogger>(_ => Log.Logger);

await builder.Build().RunAsync();
