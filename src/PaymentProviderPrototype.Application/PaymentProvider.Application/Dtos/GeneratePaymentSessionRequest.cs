using System.ComponentModel.DataAnnotations;
using PaymentProvider.Application.enums;
using PaymentProvider.Application.models;
using PaymentProvider.Common.models;
using Customer = PaymentProvider.Application.models.Customer;

namespace PaymentProvider.Application.Dtos;

public class GeneratePaymentSessionRequest(
    BillingDetails billingDetails,
    Money money,
    string successUrl,
    string failureUrl,
    string reference,
    BillingDescriptor billingDescriptor,
    Customer customer,
    string displayName,
    Locale locale = Locale.en_GB,
    bool enable3Ds = true)
{
    public Money Money { get; init; } = money;
    public BillingDetails BillingDetails { get; init; } = billingDetails;
    [Url] public string SuccessUrl { get; init; } = successUrl;
    [Url] public string FailureUrl { get; init; } = failureUrl;

    //These are optional though I think would be really useful for us to have
    public PaymentType PaymentType { get; init; }

    //string <= 50 characters
    //A reference you can use to identify the payment. For example, an order number.
    public string Reference { get; init; } = reference;
    public BillingDescriptor BillingDescriptor { get; init; } = billingDescriptor;
    public Customer Customer { get; init; } = customer;

    //string <= 255 characters. The merchant's display name.
    public string DisplayName { get; init; } = displayName;
    public Locale Locale { get; init; } = locale;
    public bool Enable3Ds { get; init; } = enable3Ds;

    public IEnumerable<PaymentMethod> EnabledPaymentMethods { get; init; }
        = new List<PaymentMethod>
        {
            PaymentMethod.card
        };
}