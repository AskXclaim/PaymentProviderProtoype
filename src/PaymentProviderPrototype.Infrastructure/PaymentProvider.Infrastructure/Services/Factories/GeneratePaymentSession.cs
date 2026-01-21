using Checkout.Common;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using PaymentProvider.Application.Dtos;
using PaymentProvider.Infrastructure.Services.Builders;
using PaymentProvider.Tests.TestData;

namespace PaymentProvider.Infrastructure.Services.Factories;

public class GeneratePaymentSession
{
    public async Task<GeneratedPaymentSessionResponse?> GetResult(GeneratePaymentSessionRequest request)
    {
        if (!PaymentSessionValidator.IsCurrencyValid(request.Money.Currency))
            throw new ProcessExitedException($"Invalid currency '{Enum.GetName(request.Money.Currency)}' provided");
        
        const Currency currency = Currency.GBP;
        var builder = new PaymentSessionBuilder();
        var paymentSessionRequest = builder.GetPaymentSessionsRequest(request, currency);
        // var paymentResponse = await _apiBuild.PaymentSessionsClient().RequestPaymentSessions
        //     (paymentSessionRequest);
        var paymentResponse = FakePaymentSessionData.GetValidFakePaymentSessionResponse();
        return paymentResponse != null ? builder.GetGeneratedPaymentSessionResponse(paymentResponse) : null;
    }
}