using PaymentProvider.Application.enums;
using PaymentProvider.Application.models;
using PaymentProvider.Common.enums;
using PaymentProvider.Common.models;

namespace PaymentProvider.Application.Dtos;

public class PaymentSessionDetailResponse
{
    public string Id { get; init; }
    public string Reference { get; init; }
    public DateTime? RequestedOn { get; init; }
    public Money Amount { get; init; }
    public PaymentStatus? Status { get; init; }
    public bool? IsApproved { get; init; }
    public PaymentType? PaymentType { get; init; }
    public string AuthenticationType { get; init; }
    public Customer Customer { get; init; }

    public PaymentSessionDetailResponse()
    {
        
    }
    public PaymentSessionDetailResponse(string id, string reference, DateTime? requestedOn, 
        Money amount, PaymentStatus? status, bool? isApproved, PaymentType? paymentType, string authenticationType, Customer customer)
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