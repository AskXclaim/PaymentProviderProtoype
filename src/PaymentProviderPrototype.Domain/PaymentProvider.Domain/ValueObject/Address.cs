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
    public string AddressLineOne { get; set; } = addressLineOne;
    public string AddressLineTwo { get; set; } = addressLineTwo;
    public string City { get; set; } = city;
    public string County { get; set; } = county;
    public AllowedCountry Country { get; set; } = country;
    public string PostalCode { get; set; } = postalCode;
}