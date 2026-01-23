using Microsoft.AspNetCore.Mvc;

namespace PaymentProvider.WebApi.Exceptions_ExceptionHandlers;

public class CustomProblemDetails:ProblemDetails
{
    public string RequestId { get; set; }
    public string? CorrelationId { get; set; }
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
}