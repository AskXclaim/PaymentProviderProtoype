using Checkout;
using PaymentProvider.Application.Dtos;
using PaymentProvider.Application.Interfaces;
using PaymentProvider.Infrastructure.Services.Builders;
using PaymentProvider.Infrastructure.Services.Factories;
using PaymentProvider.Infrastructure.Services.Factories.Interfaces;

namespace PaymentProvider.Infrastructure.Services;

public class CheckoutComPaymentGateway : IPaymentGateway
{
    private readonly ICheckoutApi _apiBuild =
        new CheckoutApiBuilder("").GetApiBuild();

    private readonly IFactory _paymentFactory;

    public CheckoutComPaymentGateway() =>
        _paymentFactory = new CheckoutPaymentMethodFactory(_apiBuild);

    public async Task<GeneratedPaymentSessionResponse?> GeneratePaymentSession(GeneratePaymentSessionRequest request) =>
        await _paymentFactory.GetResult(request) as GeneratedPaymentSessionResponse;

    public async Task<PaymentSessionDetailResponse?> GetPaymentSessionDetails(PaymentSessionDetailRequest request) =>
        await _paymentFactory.GetResult(request) as PaymentSessionDetailResponse;
}