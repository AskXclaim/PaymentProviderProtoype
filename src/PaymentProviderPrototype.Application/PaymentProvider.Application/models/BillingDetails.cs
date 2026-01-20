using PaymentProvider.Domain.ValueObject;

namespace PaymentProvider.Application.models;

public class BillingDetails(Address address, string phone)
{
    public Address Address { get; init; } = address;
    public string Phone { get; init; } = phone;
}