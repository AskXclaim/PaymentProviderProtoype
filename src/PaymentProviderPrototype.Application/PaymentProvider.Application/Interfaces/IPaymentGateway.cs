using PaymentProvider.Application.Dtos;

namespace PaymentProvider.Application.Interfaces;

public interface IPaymentGateway
{
    Task<GeneratedPaymentSessionResponse?> GeneratePaymentSession(GeneratePaymentSessionRequest  request);
    Task<PaymentSessionDetailResponse?> GetPaymentSessionDetails(string paymentSessionId);
}