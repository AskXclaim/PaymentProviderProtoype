namespace PaymentProvider.Common.Errors;

public class PaymentProviderError:Exception
{
    public string Message { get;  }
    public PaymentProviderError(string errorMessage):base(errorMessage)
    {
        Message = errorMessage;
    }
}