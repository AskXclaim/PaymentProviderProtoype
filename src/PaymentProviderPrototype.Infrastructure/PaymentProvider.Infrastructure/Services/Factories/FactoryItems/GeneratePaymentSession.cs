using Checkout;
using Checkout.Common;
using PaymentProvider.Application.Dtos;
using PaymentProvider.Infrastructure.Services.Builders;
using PaymentProvider.Infrastructure.Services.Validators;
using PaymentProvider.Tests.TestData;

namespace PaymentProvider.Infrastructure.Services.Factories.FactoryItems;

public class GeneratePaymentSession(ICheckoutApi apiBuild)
{
    public async Task<GeneratedPaymentSessionResponse?> GetResult(GeneratePaymentSessionRequest request)
    {
        if (!PaymentSessionValidator.IsCurrencyValid(request.Money.Currency))
            throw new ArgumentException($"Invalid currency '{Enum.GetName(request.Money.Currency)}' provided");
        
        const Currency currency = Currency.GBP;
        var builder = new PaymentSessionBuilder();
        var paymentSessionRequest = builder.GetPaymentSessionsRequest(request, currency);
        // var paymentResponse = await apiBuild.PaymentSessionsClient().RequestPaymentSessions
        //     (paymentSessionRequest);
        var paymentResponse = FakePaymentSessionData.GetValidFakePaymentSessionResponse();
        return paymentResponse != null ? builder.GetGeneratedPaymentSessionResponse(paymentResponse) : null;
    }
}