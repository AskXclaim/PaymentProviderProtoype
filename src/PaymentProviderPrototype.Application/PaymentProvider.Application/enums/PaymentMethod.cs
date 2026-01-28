using System.Runtime.Serialization;

namespace PaymentProvider.Application.enums;

public enum PaymentMethod
{
    [EnumMember(Value = "card")]
    Card=1,
    [EnumMember(Value = "applepay")]
    ApplePay=2,
    [EnumMember(Value = "googlepay")]
    GooglePay=3,
    [EnumMember(Value = "paypal")]
    Paypal=4
}