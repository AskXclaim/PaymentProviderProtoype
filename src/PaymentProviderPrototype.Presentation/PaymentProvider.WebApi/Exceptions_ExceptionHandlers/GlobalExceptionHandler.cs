using Microsoft.AspNetCore.Diagnostics;
using PaymentProvider.Common.Errors;

namespace PaymentProvider.WebApi.Exceptions_ExceptionHandlers;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync
        (HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "An exception occured {message}", exception.Message);
        var problemDetails = GetCustomProblemDetails(httpContext, exception);

        httpContext.Response.StatusCode = problemDetails!.Status!.Value;
        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private CustomProblemDetails GetCustomProblemDetails(HttpContext httpContext, Exception exception)
    {
        var problemDetails = new CustomProblemDetails
        {
            Status = httpContext.Response.StatusCode
        };
        if (exception.GetType() == typeof(PaymentProviderException))
        {
            var paymentProviderException = exception as PaymentProviderException;
            if (paymentProviderException?.HttpStatusCode != null)
                problemDetails.Status = (int)paymentProviderException.HttpStatusCode;

            problemDetails.Detail = paymentProviderException!.Message;
        }
        
        problemDetails.Title = "An error occured";
        problemDetails.Instance = httpContext.Request.Path;
        problemDetails.CorrelationId = "";
        problemDetails.RequestId = "";
        
        return problemDetails;
    }
}