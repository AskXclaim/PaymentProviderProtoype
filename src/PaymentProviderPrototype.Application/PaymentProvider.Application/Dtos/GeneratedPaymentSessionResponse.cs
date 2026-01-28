namespace PaymentProvider.Application.Dtos;

public class GeneratedPaymentSessionResponse
{
    public string Id { get; }
    public string Token { get; }
    public string Secret { get; }
    public string Href { get; }

    public GeneratedPaymentSessionResponse()
    {
    }   

    public GeneratedPaymentSessionResponse(string id, string token, string secret, string href)
    {
        Id = id;
        Token = token;
        Secret = secret;
        Href = href;
    }
}