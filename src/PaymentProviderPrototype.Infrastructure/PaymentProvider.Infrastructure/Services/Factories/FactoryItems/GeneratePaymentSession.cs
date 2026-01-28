using System.Net;
using Checkout;
using Checkout.Common;
using PaymentProvider.Application.Dtos;
using PaymentProvider.Common.Errors;
using PaymentProvider.Infrastructure.Services.Builders;
using PaymentProvider.Infrastructure.Services.Validators;

namespace PaymentProvider.Infrastructure.Services.Factories.FactoryItems;

public class GeneratePaymentSession(ICheckoutApi apiBuild)
{
    public async Task<GeneratedPaymentSessionResponse?> GetResult(GeneratePaymentSessionRequest request)
    {
        if (!PaymentSessionValidator.IsCurrencyValid(request.Money.Currency))
            throw new PaymentProviderException($"Invalid currency '{Enum.GetName(request.Money.Currency)}' provided",
                HttpStatusCode.BadRequest);

        const Currency currency = Currency.GBP;
        var builder = new PaymentSessionBuilder();
        var paymentSessionRequest = builder.GetPaymentSessionsRequest(request, currency);
        var paymentResponse = await apiBuild.PaymentSessionsClient().RequestPaymentSessions
            (paymentSessionRequest);
        //  var paymentResponse = FakePaymentSessionData.GetValidFakePaymentSessionResponse();
        return paymentResponse != null ? builder.GetGeneratedPaymentSessionResponse(paymentResponse) : null;
    }
}