using Microsoft.OpenApi.Models;
using Shopper.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo {Title = "Api", Version = "v1"});
    })
    .AddCors(
        policy => policy.AddDefaultPolicy(
            options => options.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                .AllowAnyHeader()
                .AllowAnyMethod())
    )
    .ConfigureJsonOptions()
    .AddFakeServices()
    .AddEndpointRouting();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
}

app.RegisterEndpoints();

app.Run();
