using System.Text.RegularExpressions;
using Checkout.Common;
using PaymentProvider.Common;
using PaymentProvider.Common.enums;
using Currency = Checkout.Common.Currency;

namespace PaymentProvider.Infrastructure.Services.Validators;

public static class PaymentSessionValidator
{
    public static bool IsCurrencyValid(Common.enums.Currency currency) =>
        GlobalMethods.ParseEnum<Currency>(currency.ToString()).ToString() != null;

    public static CountryCode GetCountryCode(AllowedCountry allowedCountry)
    {
        return allowedCountry.ToString().ToUpper() switch
        {
            nameof(CountryCode) => CountryCode.GB,
            _ => CountryCode.GB
        };
    }

    public static bool IsPaymentSessionIdValid(string paymentSessionId)
    {
        if (string.IsNullOrWhiteSpace(paymentSessionId))
            return false;

        return Regex.IsMatch(
            paymentSessionId, @"^(pay|sid)_(\w{26})$");

        #region Notes about the @"^(pay|sid)_(\w{26})$")

        //^ — start of the string
        //(pay|sid) — the string must begin with either pay or sid
        //_ — a literal underscore
        //(\w{26}) — exactly 26 “word” characters, where \w means:
        //letters A–Z / a–z
        //digits 0–9
        //underscore _
        //$ — end of the string
        //Examples that match:
        //pay_abc123DEF456ghi789JKL012
        //sid_A1b2C3d4E5f6G7h8I9j0K1L2

        #endregion
    }
}