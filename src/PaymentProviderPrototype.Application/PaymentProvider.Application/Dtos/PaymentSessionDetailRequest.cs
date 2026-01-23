using System.ComponentModel.DataAnnotations;

namespace PaymentProvider.Application.Dtos;

public class PaymentSessionDetailRequest(string paymentSessionId)
{
    [Required]
    public string PaymentSessionId { get; init; } = paymentSessionId;
}