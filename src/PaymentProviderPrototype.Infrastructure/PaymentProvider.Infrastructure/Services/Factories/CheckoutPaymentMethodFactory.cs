using System.Net;
using Checkout;
using PaymentProvider.Application.Dtos;
using PaymentProvider.Common.Errors;
using PaymentProvider.Infrastructure.Services.Factories.FactoryItems;
using PaymentProvider.Infrastructure.Services.Factories.Interfaces;

namespace PaymentProvider.Infrastructure.Services.Factories;

public class CheckoutPaymentMethodFactory(ICheckoutApi apiBuilder) : IFactory
{
    public async Task<object?> GetResult(object request)
    {
        try
        {
            switch (request.GetType().Name)
            {
                case nameof(GeneratePaymentSessionRequest):
                    var generatePaymentSession = new GeneratePaymentSession(apiBuilder);
                    return await generatePaymentSession.GetResult((GeneratePaymentSessionRequest)request);
                case nameof(PaymentSessionDetailRequest):
                    var getPaymentSessionDetails = new GetPaymentSessionDetails(apiBuilder);
                    return await getPaymentSessionDetails.GetResult(((PaymentSessionDetailRequest)request)
                        .PaymentSessionId);
                default:
                    throw new PaymentProviderException($"Unknown request type {request.GetType().Name}",
                        HttpStatusCode.InternalServerError);
            }
        }
        // Todo: We may want to treat each exception differently
        catch (CheckoutApiException exception)
        {
            throw new PaymentProviderException(exception.Message, exception.HttpStatusCode);
        }
        catch (CheckoutArgumentException exception)
        {
            throw new PaymentProviderException(exception.Message, HttpStatusCode.InternalServerError);
        }
        catch (CheckoutAuthorizationException exception)
        {
            throw new PaymentProviderException(exception.Message, HttpStatusCode.Unauthorized);
        }
        catch (PaymentProviderException exception)
        {
            throw new PaymentProviderException(exception.Message, exception.HttpStatusCode);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }
}