using System.Net;

namespace PaymentProvider.Common.Errors;

public class PaymentProviderError
    (string errorContent, HttpStatusCode statusCode) : Exception(errorContent)
{
    public string Content { get;  } = errorContent;
    public HttpStatusCode HttpStatusCode { get;  } = statusCode;
}