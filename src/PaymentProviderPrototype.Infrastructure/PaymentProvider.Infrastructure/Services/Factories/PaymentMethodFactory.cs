using System.Net;
using Checkout;
using PaymentProvider.Application.Dtos;
using PaymentProvider.Common.Errors;
using PaymentProvider.Infrastructure.Services.Factories.Interfaces;

namespace PaymentProvider.Infrastructure.Services.Factories;

public class PaymentMethodFactory : IFactory
{
    public async Task<object?> GetResult(object request)
    {
        try
        {
            switch (request.GetType().Name)
            {
                case nameof(GeneratePaymentSessionRequest):
                    var generatePaymentSession = new GeneratePaymentSession();
                    return await generatePaymentSession.GetResult((GeneratePaymentSessionRequest)request);
                default:
                    throw new PaymentProviderError($"Unknown request type {request.GetType().Name}",
                        HttpStatusCode.InternalServerError);
            }
        }
        // Todo: We may want to treat each exception differently
        catch (CheckoutApiException exception)
        {
            throw new PaymentProviderError(exception.Message, exception.HttpStatusCode);
        }
        catch (CheckoutArgumentException exception)
        {
            throw new PaymentProviderError(exception.Message, HttpStatusCode.InternalServerError);
        }
        catch (CheckoutAuthorizationException exception)
        {
            throw new PaymentProviderError(exception.Message, HttpStatusCode.Unauthorized);
        }
        catch (Exception exception)
        {
            throw new PaymentProviderError(exception.Message, HttpStatusCode.InternalServerError);
        }
    }
}