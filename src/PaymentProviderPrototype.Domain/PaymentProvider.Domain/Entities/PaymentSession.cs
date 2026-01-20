using PaymentProvider.Common.models;

namespace PaymentProvider.Domain.Entities;

public class PaymentSession(string sessionId, string redirectUrl, Money money)
{
    public string SessionId { get; init; } = sessionId;
    public string RedirectUrl { get; init; } = redirectUrl;
    public Money Amount { get; init; } = money;
}