using PaymentProvider.Domain.Entities;

namespace PaymentProvider.Domain.Repositories;

public interface IPaymentRepository
{
    Task<PaymentSession> GetPaymentSession(string sessionId);
}