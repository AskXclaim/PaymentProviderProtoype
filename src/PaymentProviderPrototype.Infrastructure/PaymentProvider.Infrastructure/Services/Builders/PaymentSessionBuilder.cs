using Checkout.Common;
using Checkout.Payments;
using Checkout.Payments.Request;
using Checkout.Payments.Sessions;
using PaymentProvider.Application.Dtos;
using PaymentProvider.Common;
using PaymentProvider.Infrastructure.Services.Validators;

namespace PaymentProvider.Infrastructure.Services.Builders;

public class PaymentSessionBuilder
{
    private const string CountryCode = "44";

    public PaymentSessionsRequest GetPaymentSessionsRequest
        (GeneratePaymentSessionRequest request)
    {
        return new PaymentSessionsRequest
        {
            Amount = (long)request.Money.Amount,
            Currency = GlobalMethods.ParseEnum<Currency>(request.Money.Currency.ToString()),
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
                    CountryCode = CountryCode,
                    Number = request.BillingDetails.Phone
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
                Email = request.Customer.Email
            },
            ProcessingChannelId = request.ProcessingChannelId,
            PaymentType = GlobalMethods.ParseEnum<PaymentType>(request.PaymentType.ToString()),
            SuccessUrl = request.SuccessUrl,
            FailureUrl = request.FailureUrl
        };
    }

    public GeneratedPaymentSessionResponse GetGeneratedPaymentSessionResponse(
        PaymentSessionsResponse paymentResponse)
    {
        return new GeneratedPaymentSessionResponse
        (
            paymentResponse.Id, paymentResponse.PaymentSessionSecret,
            paymentResponse.PaymentSessionToken, paymentResponse.GetSelfLink().Href
        );
    }
}