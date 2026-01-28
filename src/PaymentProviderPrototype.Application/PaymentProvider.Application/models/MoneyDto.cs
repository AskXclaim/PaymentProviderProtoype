namespace PaymentProvider.Application.models;

public class MoneyDto(decimal amount, string currency)
{
    public decimal Amount { get; set; } = amount;
    public string Currency { get; set; } = currency;
}