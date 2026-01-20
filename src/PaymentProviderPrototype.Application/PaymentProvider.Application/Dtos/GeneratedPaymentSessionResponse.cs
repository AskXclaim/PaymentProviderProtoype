namespace PaymentProvider.Application.Dtos;

public class GeneratedPaymentSessionResponse
{
    public string Id { get; init; }
    public string Token { get; init; }
    public string Secret { get; init; }
    public string Href { get; init; }

    public GeneratedPaymentSessionResponse() { }
    public GeneratedPaymentSessionResponse(string id, string token, string secret, string href)
    {
        Id = id;
        Token = token;
        Secret = secret;
        Href = href;
    }
}