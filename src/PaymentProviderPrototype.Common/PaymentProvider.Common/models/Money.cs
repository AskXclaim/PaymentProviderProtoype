using PaymentProvider.Common.enums;

namespace PaymentProvider.Common.models;

public class Money(decimal amount, Currency currency)
{
    public decimal Amount { get; set; } = amount;
    public Currency Currency { get; set; } = currency;
}