using PaymentProvider.Common.enums;

namespace PaymentProvider.Domain.ValueObject;

public class Address(
    string addressLineOne,
    string addressLineTwo,
    string city,
    string county,
    AllowedCountry country,
    string postalCode)
{
    public string AddressLineOne { get; } = addressLineOne;
    public string AddressLineTwo { get; } = addressLineTwo;
    public string City { get; } = city;
    public string County { get; } = county;
    public AllowedCountry Country { get; } = country;
    public string PostalCode { get; } = postalCode;
}