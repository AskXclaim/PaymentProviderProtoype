using PaymentProvider.Domain.ValueObject;

namespace PaymentProvider.Application.models;

public class BillingDetails(Address address, string phone)
{
    public Address Address { get; set; } = address;
    public string Phone { get; set; } = phone;
}