using Checkout;
using Environment = Checkout.Environment;


namespace PaymentProvider.Infrastructure.Services.Builders;

public class CheckoutApiBuilder(string secretKey, string? publicKey=null, Environment environment=Environment.Sandbox)
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
    // .PublicKey("pk_sbox_vifq7ttmts42gxjkz2gnfq7y6y2")
    // .SecretKey("sk_sbox_coj3lh7xqkjsrom3m7htqzvryel")
    // .EnvironmentSubdomain("localhost")
    // .LogProvider(new NullLoggerFactory())
}