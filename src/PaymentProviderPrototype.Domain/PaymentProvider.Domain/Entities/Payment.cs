using PaymentProvider.Common.models;
using PaymentProvider.Domain.ValueObject;

namespace PaymentProvider.Domain.Entities;

public class Payment
{
    public Money Money { get; }
    public string Reference { get; }
    public Address BillingAddress { get; }

    public Payment(string reference, Money money, Address billingAddress)
    {
        Reference = reference;
        Money = GetMoney(money);
        BillingAddress = billingAddress;
    }

    private Money GetMoney(Money money) =>
        money.Amount < 0 ? new Money(0M, money.Currency) : money;
}