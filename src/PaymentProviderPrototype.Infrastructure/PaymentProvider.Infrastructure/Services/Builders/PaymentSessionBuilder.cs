using Checkout.Common;
using Checkout.Payments;
using Checkout.Payments.Request;
using Checkout.Payments.Sessions;
using PaymentProvider.Application.Dtos;

namespace PaymentProvider.Infrastructure.Services.Builders;

public class PaymentSessionBuilder
{
    public PaymentSessionsRequest GetPaymentSessionsRequest
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

    public GeneratedPaymentSessionResponse GetGeneratedPaymentSessionResponse(
        PaymentSessionsResponse paymentResponse)
    {
        return new GeneratedPaymentSessionResponse
        {
            Id = paymentResponse.Id, Secret = paymentResponse.PaymentSessionSecret,
            Token = paymentResponse.PaymentSessionToken, Href = paymentResponse.GetSelfLink().Href
        };
    }
}