using Checkout.Common;
using PaymentProvider.Common.enums;
using Currency = Checkout.Common.Currency;

namespace PaymentProvider.Infrastructure.Services;

public static class PaymentSessionValidator
{
    public static bool IsCurrencyValid(Common.enums.Currency currency) =>
        Enum.GetName(currency)?.ToUpper() == Enum.GetName(Currency.GBP)?.ToUpper();

    public static CountryCode GetCountryCode(AllowedCountry allowedCountry)
    {
        return Enum.GetName(allowedCountry)?.ToUpper() switch
        {
            nameof(CountryCode) => CountryCode.GB,
            _ => CountryCode.GB
        };
    }
}