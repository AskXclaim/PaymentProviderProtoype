using System.Net;
using Checkout;
using Checkout.Common;
using Checkout.Payments.Response;
using PaymentProvider.Application.Dtos;
using PaymentProvider.Application.enums;
using PaymentProvider.Application.models;
using PaymentProvider.Common;
using PaymentProvider.Common.enums;
using PaymentProvider.Common.Errors;
using PaymentProvider.Infrastructure.Services.Validators;
using Currency = Checkout.Common.Currency;

namespace PaymentProvider.Infrastructure.Services.Factories.FactoryItems;

public class GetPaymentSessionDetails(ICheckoutApi apiBuild)
{
    public async Task<PaymentSessionDetailResponse?> GetResult(string paymentSessionId)
    {
        if (!PaymentSessionValidator.IsPaymentSessionIdValid(paymentSessionId))
            throw new PaymentProviderException
                ($"Please provide a valid {nameof(paymentSessionId)}.", HttpStatusCode.BadRequest);

        var result = await apiBuild.PaymentsClient().GetPaymentDetails(paymentSessionId);

        if (result is null)
            throw new PaymentProviderException
                ($"Null result gotten from GetPaymentDetails", HttpStatusCode.InternalServerError);

        return ParseResponse(result);
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

    private MoneyDto ParseMoney(long? amount, Currency? currency)
    {
        var anAmount = amount ?? 0;
        var aCurrency = Common.enums.Currency.GBP;
        if (amount.HasValue) anAmount = amount.Value;

        if (currency.HasValue)
            aCurrency = GlobalMethods.ParseEnum<Common.enums.Currency>(currency.Value.ToString());

        return new MoneyDto(anAmount, aCurrency.ToString());
    }

    private string? ParsePaymentStatus(Checkout.Payments.PaymentStatus? status)
        => status is null
            ? null
            : GlobalMethods.ParseEnum<PaymentStatus>
                (status.Value.ToString()).ToString();

    private string? ParsePaymentType(Checkout.Payments.PaymentType? paymentType)
        => paymentType is null
            ? null
            : GlobalMethods.ParseEnum<PaymentType>(paymentType.Value.ToString()).ToString();

    private Customer ParseCustomer(CustomerResponse customer) =>
        new()
        {
            Id = customer.Id,
            FirstName = customer.Name,
            LastName = customer.Name,
            Email = customer.Email
        };
}