using PaymentProvider.Common.models;

namespace PaymentProvider.Domain.Entities;

public class PaymentSession(string sessionId, string redirectUrl, Money money)
{
    public string SessionId { get; } = sessionId;
    public string RedirectUrl { get; } = redirectUrl;
    public Money Amount { get; } = money;
}