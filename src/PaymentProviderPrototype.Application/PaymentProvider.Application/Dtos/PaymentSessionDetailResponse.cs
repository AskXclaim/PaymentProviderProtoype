using PaymentProvider.Application.models;

namespace PaymentProvider.Application.Dtos;

public class PaymentSessionDetailResponse
{
    public string Id { get; init; }
    public string Reference { get; init; }
    public DateTime? RequestedOn { get; init; }
    public MoneyDto Amount { get; init; }
    public string? Status { get; init; }
    public bool? IsApproved { get; init; }
    public string? PaymentType { get; init; }
    public string AuthenticationType { get; init; }
    public Customer Customer { get; init; }

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