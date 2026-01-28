using PaymentProvider.Application.models;

namespace PaymentProvider.Application.Dtos;

public class PaymentSessionDetailResponse
{
    public string Id { get; set; }
    public string Reference { get; set; }
    public DateTime? RequestedOn { get; set; }
    public MoneyDto Amount { get; set; }
    public string? Status { get; set; }
    public bool? IsApproved { get; set; }
    public string? PaymentType { get; set; }
    public string AuthenticationType { get; set; }
    public Customer Customer { get; set; }

    public PaymentSessionDetailResponse()
    {
    }

    public PaymentSessionDetailResponse(string id, string reference, DateTime? requestedOn,
        MoneyDto amount, string? status, bool? isApproved, string? paymentType,
        string authenticationType, Customer customer)
    {
        Id = id;
        Reference = reference;
        RequestedOn = requestedOn;
        Amount = amount;
        Status = status;
        IsApproved = isApproved;
        PaymentType = paymentType;
        AuthenticationType = authenticationType;
        Customer = customer;
    }
}