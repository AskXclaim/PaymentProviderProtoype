using Checkout;
using Checkout.Common;
using Checkout.Payments.Response;
using PaymentProvider.Application.Dtos;
using PaymentProvider.Application.enums;
using PaymentProvider.Application.models;
using PaymentProvider.Common.enums;
using PaymentProvider.Common.models;
using PaymentProvider.Infrastructure.Services.Validators;
using Currency = Checkout.Common.Currency;

namespace PaymentProvider.Infrastructure.Services.Factories.FactoryItems;

public class GetPaymentSessionDetails(ICheckoutApi apiBuild)
{
    public const string PaymentSessionId = "paymentSessionId";
    public async Task<PaymentSessionDetailResponse?> GetResult(string paymentSessionId)
    {
        if (!PaymentSessionValidator.IsPaymentSessionIdValid(paymentSessionId))
            throw new ArgumentException($"{nameof(paymentSessionId)} cannot be null or whitespace.");

        var result = await apiBuild.PaymentsClient().GetPaymentDetails(paymentSessionId);

        if (result is null)
            throw new Exception($"No null result gotten from GetPaymentDetails");

        var response = ParseResponse(result);
        return response;
    }

    private PaymentSessionDetailResponse ParseResponse(GetPaymentResponse result)
    {
        return new PaymentSessionDetailResponse()
        {
            Id = result.Id, RequestedOn = result.RequestedOn,
            Reference = result.Reference,
            Amount = ParseMoney(result.Amount, result.Currency),
            Status = ParsePaymentStatus(result.Status),
            IsApproved = result.Approved,
            PaymentType = ParsePaymentType(result.PaymentType),
            Customer = ParseCustomer(result.Customer)
        };
    }
    
    private Money ParseMoney(long? amount, Currency? currency)
    {
        var anAmount = amount ?? 0;
        var aCurrency = Common.enums.Currency.GBP;
        if (amount.HasValue) anAmount = amount.Value;

        if (currency.HasValue)
            aCurrency = ParseEnum<Common.enums.Currency>(currency.Value);

        return new Money(anAmount, aCurrency);
    }

    private PaymentStatus? ParsePaymentStatus(Checkout.Payments.PaymentStatus? status)
        => status is null ? null : ParseEnum<PaymentStatus>(status.Value);

    private PaymentType? ParsePaymentType(Checkout.Payments.PaymentType? paymentType)
        => paymentType is null ? null : ParseEnum<PaymentType>(paymentType.Value);

    private Customer ParseCustomer(CustomerResponse customer) =>
        new()
        {
            Id = customer.Id,
            FirstName = customer.Name,
            LastName = customer.Name,
            Email = customer.Email,
        };
    
    private TEnum ParseEnum<TEnum>(Enum value)
        where TEnum : struct, Enum
    {
        return (TEnum)Enum.ToObject(typeof(TEnum), value);
        // return (TEnum)Enum.Parse(typeof(TEnum), Enum.GetName(value));
    }
}