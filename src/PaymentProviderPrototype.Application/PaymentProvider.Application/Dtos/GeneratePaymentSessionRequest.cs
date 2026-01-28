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
    Locale locale = Locale.EnGb,
    bool enable3Ds = true)
{
    public Money Money { get; set; } = money;
    public BillingDetails BillingDetails { get; set; } = billingDetails;
    public string SuccessUrl { get; set; } = successUrl;
    public string FailureUrl { get; set; } = failureUrl;

    //These are optional though I think would be really useful for us to have
    public PaymentType PaymentType { get; set; }

    //string <= 50 characters
    //A reference you can use to identify the payment. For example, an order number.
    public string Reference { get; set; } = reference;
    public BillingDescriptor BillingDescriptor { get; set; } = billingDescriptor;
    public Customer Customer { get; set; } = customer;

    //string <= 255 characters. The merchant's display name.
    public string DisplayName { get; set; } = displayName;
    public Locale Locale { get; set; } = locale;
    public bool Enable3Ds { get; set; } = enable3Ds;

    public IEnumerable<PaymentMethod> EnabledPaymentMethods { get; set; }
        = new List<PaymentMethod>
        {
            PaymentMethod.Card
        };
}