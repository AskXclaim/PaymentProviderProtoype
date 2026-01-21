namespace PaymentProvider.Infrastructure.Services.Factories.Interfaces;

public interface IFactory
{
    Task<object?> GetResult(object request);
}