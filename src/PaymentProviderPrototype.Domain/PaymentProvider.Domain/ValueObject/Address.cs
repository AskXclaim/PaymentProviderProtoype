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
    public string AddressLineOne { get; init; } = addressLineOne;
    public string AddressLineTwo { get; init; } = addressLineTwo;
    public string City { get; init; } = city;
    public string County { get; init; } = county;
    public AllowedCountry Country { get; init; } = country;
    public string PostalCode { get; init; } = postalCode;
}