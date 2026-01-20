namespace PaymentProvider.Common.Errors;

public class PaymentProviderError:Exception
{
    public string Message { get; init; }
    public PaymentProviderError()
    {
        
    }
}