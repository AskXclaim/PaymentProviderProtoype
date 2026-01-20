using Microsoft.AspNetCore.Mvc;
using PaymentProvider.Application.Dtos;
using PaymentProvider.Infrastructure.Services;

namespace PaymentProvider.WebApi;

public static class PaymentEndpoints
{
    public static RouteGroupBuilder MapPaymentEndpoints(this RouteGroupBuilder groupBuilder)
    {

        groupBuilder.MapPost("/GeneratePaymentSession", async ([FromBody] GeneratePaymentSessionRequest request) =>
        {
            var apiGateway = new CheckoutComPaymentGateway();
            var response = await apiGateway.GeneratePaymentSession(request);
            return response;
        });
        
        return groupBuilder;
    }
}