using System.Net;
using Checkout;
using Checkout.Common;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using PaymentProvider.Application.Dtos;
using PaymentProvider.Application.Interfaces;
using PaymentProvider.Common.Errors;
using PaymentProvider.Infrastructure.Services.Builders;
using PaymentProvider.Infrastructure.Services.Factories;
using PaymentProvider.Infrastructure.Services.Factories.Interfaces;
using PaymentProvider.Tests.TestData;

namespace PaymentProvider.Infrastructure.Services;

public class CheckoutComPaymentGateway : IPaymentGateway
{
    private readonly ICheckoutApi _apiBuild = new ApiBuilder("sk_sbox_coj3lh7xqkjsrom3m7htqzvryel").GetApiBuild();
    private readonly IFactory _paymentFactory = new PaymentMethodFactory();

    public async Task<GeneratedPaymentSessionResponse?> GeneratePaymentSession(GeneratePaymentSessionRequest request)
    {
     return  await _paymentFactory.GetResult(request) as GeneratedPaymentSessionResponse;
    }

    public async Task<PaymentSessionDetailsResponse> GetPaymentSessionDetails(string sessionId)
    {
        try
        {
          var result =   await _apiBuild.PaymentsClient().GetPaymentDetails(sessionId);
          if (result != null)
          {
              
          }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}