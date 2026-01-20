using PaymentProvider.Application.Interfaces;
using PaymentProvider.Infrastructure.Services;
using PaymentProvider.WebApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    // Specify the OpenAPI version to use
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "Payment-Provider-WebApi";
    config.Title = "Payment-Provider-WebApi v1";
    config.Version = "v1";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "Payment-Provider-WebApi";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Payment-Provider-WebApi");
    });
}

app.UseHttpsRedirection();

app.MapGroup("/api/payments").MapPaymentEndpoints();

app.Run();
