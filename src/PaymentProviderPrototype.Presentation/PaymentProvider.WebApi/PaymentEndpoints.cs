using System.Net;
using Microsoft.AspNetCore.Mvc;
using PaymentProvider.Application.Dtos;
using PaymentProvider.Application.Interfaces;
using PaymentProvider.Common.Errors;
using PaymentProvider.Common.models;

namespace PaymentProvider.WebApi;

public static class PaymentEndpoints
{
    public static RouteGroupBuilder MapPaymentEndpoints(this RouteGroupBuilder groupBuilder)
    {
        //ToDO write a global error handler
        groupBuilder.MapPost("/GeneratePaymentSession",
            async (IPaymentGateway paymentGateway, [FromBody] GeneratePaymentSessionRequest request) =>
            {
                try
                {
                    var response = await paymentGateway.GeneratePaymentSession(request);
                    if (response != null) return new Response(response, HttpStatusCode.OK);
                }
                catch (PaymentProviderError error)
                {
                    return GetExceptionResponse(error);
                }

                return GetFailedResponse();
            });

        groupBuilder.MapGet("/GetPaymentSessionDetails",
            async (IPaymentGateway paymentGateway, string paymentSessionId) =>
            {
                try
                {
                    var response = await paymentGateway.GetPaymentSessionDetails(paymentSessionId);
                    if (response != null) return new Response(response, HttpStatusCode.OK);
                }
                catch (PaymentProviderError error)
                {
                    return GetExceptionResponse(error);
                }

                return GetFailedResponse();
            });

        return groupBuilder;
    }

    private static Response GetFailedResponse() =>
        new Response("An unexpected situation occurred please try again",
            HttpStatusCode.Ambiguous, true);

    private static Response GetExceptionResponse(PaymentProviderError error) =>
        new Response(error.Content, error.HttpStatusCode, true);
}