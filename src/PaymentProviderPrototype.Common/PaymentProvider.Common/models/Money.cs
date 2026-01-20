using PaymentProvider.Common.enums;

namespace PaymentProvider.Common.models;

public class Money(decimal amount, Currency currency)
{
    public decimal Amount { get; init; } = amount;
    public Currency Currency { get; init; } = currency;
}