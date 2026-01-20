using System.Net;
using Checkout;
using Checkout.Common;
using Checkout.Payments.Sessions;

namespace PaymentProvider.Tests.TestData;

public static class FakePaymentSessionData
{
    public static PaymentSessionsResponse? GetValidFakePaymentSessionResponse()
    {
        return new PaymentSessionsResponse()
        {
            Id = "ps_2Un6I6lRpIAiIEwQIyxWVnV9CqQ", PaymentSessionToken = "9245fe4a-d402-451c-b9ed-9c1a04247482",
            PaymentSessionSecret = "pss_9823241e-2cec-4c98-b23d-7b29ow4e2e34", Links = new Dictionary<string, Link>()
            {
                {
                    "self", new Link()
                    {
                        Href =
                            "https://{prefix}.api.sandbox.checkout.com/payment-sessions/ps_2Un6I6lRpIAiIEwQIyxWVnV9CqQ"
                    }
                }
            }
        };
    }

    public static CheckoutApiException GetInvalidFakePaymentSessionResponse()
    {
        return new CheckoutApiException("f4b05807-97d0-4e51-96c8-326bf3953af1",
            HttpStatusCode.BadRequest, new Dictionary<string, object>()
            {
                { "validation_error", "[\n  \"processing_channel_id_required\"\n]" }
            });
    }
}