using System.Runtime.Serialization;

namespace PaymentProvider.Common.enums;

public enum PaymentStatus
{
    [EnumMember(Value = "Authorized")] Authorized,
    [EnumMember(Value = "Approved")]Approved = 2,
    [EnumMember(Value = "Canceled")]Canceled = 3,
    [EnumMember(Value = "Captured")] Captured = 4,
    [EnumMember(Value = "Declined")]Declined = 5,
    [EnumMember(Value = "Expired")] Expired = 6,
    [EnumMember(Value = "Paid")] Paid = 7,
    [EnumMember(Value = "Pending")] Pending = 8,
    [EnumMember(Value = "Refunded")] Refunded = 9,
    [EnumMember(Value = "Returned")]  Returned = 10
}