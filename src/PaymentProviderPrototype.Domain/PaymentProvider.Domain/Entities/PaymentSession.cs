using PaymentProvider.Common.models;

namespace PaymentProvider.Domain.Entities;

public class PaymentSession(string sessionId, string redirectUrl, Money money)
{
    public string SessionId { get; set; } = sessionId;
    public string RedirectUrl { get; set; } = redirectUrl;
    public Money Amount { get; set; } = money;
}