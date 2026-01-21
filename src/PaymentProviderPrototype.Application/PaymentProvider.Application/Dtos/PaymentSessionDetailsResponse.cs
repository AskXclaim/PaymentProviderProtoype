using PaymentProvider.Application.models;
using PaymentProvider.Common.models;

namespace PaymentProvider.Application.Dtos;

public class PaymentSessionDetailsResponse
{
    public string Id { get; set; }
    public DateTime RequestedOn { get; set; }
    public Money Amount { get; set; }
    public string Status { get; set; }
    public bool IsApproved { get; set; }
    public string AuthenticationType { get; set; }
    public Customer Customer { get; set; }
}