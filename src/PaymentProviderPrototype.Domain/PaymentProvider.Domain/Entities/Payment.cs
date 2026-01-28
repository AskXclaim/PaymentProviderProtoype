using PaymentProvider.Common.enums;
using PaymentProvider.Common.models;
using PaymentProvider.Domain.ValueObject;

namespace PaymentProvider.Domain.Entities;

public class Payment
{
    public Money Money { get; set; } = new Money(0.00M, Currency.GBP);
    public string Reference { get; set; }
    public Address BillingAddress { get; set; }
}