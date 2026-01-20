using PaymentProvider.Common.enums;
using PaymentProvider.Common.models;
using PaymentProvider.Domain.ValueObject;

namespace PaymentProvider.Domain.Entities;

public class Payment
{
    public Money Money { get; init; } = new Money(0.00M, Currency.GBP);
    public string Reference { get; init; }
    public Address BillingAddress { get; init; }
}