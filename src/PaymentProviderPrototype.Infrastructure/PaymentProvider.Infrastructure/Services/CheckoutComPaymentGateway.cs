using Checkout;
using Checkout.Common;
using Checkout.Payments;
using Checkout.Payments.Request;
using Checkout.Payments.Sessions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using PaymentProvider.Application.Dtos;
using PaymentProvider.Application.Interfaces;
using PaymentProvider.Common.Errors;
using PaymentProvider.Tests.TestData;
using Environment = Checkout.Environment;

namespace PaymentProvider.Infrastructure.Services;

public class CheckoutComPaymentGateway : IPaymentGateway
{
    public async Task<GeneratedPaymentSessionResponse?> GeneratePaymentSession(GeneratePaymentSessionRequest request)
    {
        if (!PaymentSessionValidator.IsCurrencyValid(request.Money.Currency))
            throw new ProcessExitedException($"Invalid currency '{Enum.GetName(request.Money.Currency)}' provided");

        const Currency currency = Currency.GBP;
        try
        {
            var api = GetApiBuild();
            var paymentSessionRequest = GetPaymentSessionsRequest(request, currency);
            // var paymentResponse = await api.PaymentSessionsClient().RequestPaymentSessions
            //     (paymentSessionRequest);
            var paymentResponse = FakePaymentSessionData.GetValidFakePaymentSessionResponse();
            return paymentResponse != null ? GetGeneratedPaymentSessionResponse(paymentResponse) : null;
        }
        // Todo: We may want to treat each exception differently
        catch (CheckoutApiException exception)
        {
          throw new PaymentProviderError(exception.Message);
        }
        catch (CheckoutArgumentException exception)
        {
            throw new PaymentProviderError(exception.Message);
        }
        catch (CheckoutAuthorizationException exception)
        {
           throw new PaymentProviderError(exception.Message);
        }
        catch (Exception exception)
        {
            throw new PaymentProviderError(exception.Message);
        }
    }

    private ICheckoutApi GetApiBuild()
    {
        return CheckoutSdk.Builder().StaticKeys()
            .PublicKey("pk_sbox_vifq7ttmts42gxjkz2gnfq7y6y2")
            .SecretKey("sk_sbox_coj3lh7xqkjsrom3m7htqzvryel")
            .Environment(Environment.Sandbox)
            .HttpClientFactory(new DefaultHttpClientFactory())
            // .EnvironmentSubdomain("localhost")
            // .LogProvider(new NullLoggerFactory())
            .Build();
    }

    private PaymentSessionsRequest GetPaymentSessionsRequest
        (GeneratePaymentSessionRequest request, Currency currency)
    {
        return new PaymentSessionsRequest
        {
            Amount = (long)request.Money.Amount,
            Currency = currency,
            Billing = new BillingInformation
            {
                Address = new Address
                {
                    Country = PaymentSessionValidator.GetCountryCode(request.BillingDetails.Address.Country),
                    AddressLine1 = request.BillingDetails.Address.AddressLineOne,
                    AddressLine2 = request.BillingDetails.Address.AddressLineTwo,
                    City = request.BillingDetails.Address.City,
                    Zip = request.BillingDetails.Address.PostalCode
                },
                Phone = new Phone
                {
                    CountryCode = "44",
                    Number = request.BillingDetails.Phone,
                }
            },
            ThreeDs = new ThreeDsRequest()
            {
                Enabled = true,
                ChallengeIndicator = ChallengeIndicatorType.ChallengeRequestedMandate
            },
            PaymentMethodConfiguration = new PaymentMethodConfiguration()
            {
                Card = new Card()
                {
                    StorePaymentDetails = StorePaymentDetailsType.Enabled
                }
            },
            Customer = new PaymentCustomerRequest()
            {
                Name = $"{request.Customer.FirstName} {request.Customer.LastName}",
                Email = request.Customer.Email,
            },
            ProcessingChannelId = "pc_dkgoofpvuwuerekvd4ssr6jwom",
           PaymentType = PaymentType.Recurring,
            SuccessUrl = "Http://localhost/successfUrl.com",
            FailureUrl = "Http://localhost/failureUrl.com",
        };
    }

    private GeneratedPaymentSessionResponse GetGeneratedPaymentSessionResponse(
        PaymentSessionsResponse paymentResponse)
    {
        return new GeneratedPaymentSessionResponse
        {
            Id = paymentResponse.Id, Secret = paymentResponse.PaymentSessionSecret,
            Token = paymentResponse.PaymentSessionToken, Href = paymentResponse.GetSelfLink().Href
        };
    }
}