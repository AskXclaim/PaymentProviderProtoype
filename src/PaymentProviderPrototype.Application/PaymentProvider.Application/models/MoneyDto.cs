using PaymentProvider.Common.enums;

namespace PaymentProvider.Application.models;

public class MoneyDto(decimal amount, string? currency)
{
    public decimal Amount { get; init; } = amount;
    public string Currency { get; init; } = currency;
}