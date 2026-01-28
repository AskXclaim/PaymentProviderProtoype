using Checkout;
using Environment = Checkout.Environment;


namespace PaymentProvider.Infrastructure.Services.Builders;

public class CheckoutApiBuilder(
    string secretKey,
    string? publicKey = null,
    Environment environment = Environment.Sandbox)
{
    public ICheckoutApi GetApiBuild()
    {
        if (string.IsNullOrEmpty(publicKey))
        {
            return CheckoutSdk.Builder().StaticKeys()
                .PublicKey(publicKey)
                .SecretKey(secretKey)
                .Environment(environment)
                .HttpClientFactory(new DefaultHttpClientFactory())
                .Build();
        }

        return CheckoutSdk.Builder().StaticKeys()
            .SecretKey(secretKey)
            .Environment(environment)
            .HttpClientFactory(new DefaultHttpClientFactory())
            .Build();
    }
}