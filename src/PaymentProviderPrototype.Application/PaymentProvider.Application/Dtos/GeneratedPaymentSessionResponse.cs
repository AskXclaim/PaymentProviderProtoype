namespace PaymentProvider.Application.Dtos;

public class GeneratedPaymentSessionResponse
{
    public string Id { get; private set; }
    public string Token { get; private set; }
    public string Secret { get; private set; }
    public string Href { get; private set; }

    public GeneratedPaymentSessionResponse() { }
    public GeneratedPaymentSessionResponse(string id, string token, string secret, string href)
    {
        Id = id;
        Token = token;
        Secret = secret;
        Href = href;
    }
}