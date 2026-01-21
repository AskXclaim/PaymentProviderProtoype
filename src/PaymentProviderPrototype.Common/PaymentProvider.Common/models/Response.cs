using System.Net;

namespace PaymentProvider.Common.models;

public class Response(object data, HttpStatusCode statusCode, bool isErrored = false)
{
    public object Data { get; } = data;
    public HttpStatusCode StatusCode { get; } = statusCode;
    public bool IsErrored { get; } = isErrored;
}