using System.Net;
using Checkout;
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
            throw new PaymentProviderException($"Invalid currency '{request.Money.Currency.ToString()}'" +
                                               $" provided", HttpStatusCode.BadRequest);

        var paymentSessionBuilder = new PaymentSessionBuilder();
        var paymentSessionRequest = paymentSessionBuilder.GetPaymentSessionsRequest(request);
        var paymentResponse = await apiBuild.PaymentSessionsClient().RequestPaymentSessions
            (paymentSessionRequest);
        return paymentResponse != null
            ? paymentSessionBuilder.GetGeneratedPaymentSessionResponse(paymentResponse)
            : null;
    }
}