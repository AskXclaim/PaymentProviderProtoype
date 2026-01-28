namespace PaymentProvider.Application.Dtos;

public class PaymentSessionDetailRequest(string paymentSessionId)
{
    public string PaymentSessionId { get; set; } = paymentSessionId;
}