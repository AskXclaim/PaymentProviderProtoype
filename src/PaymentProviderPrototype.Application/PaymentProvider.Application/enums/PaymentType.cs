using System.Runtime.Serialization;

namespace PaymentProvider.Application.enums;

public enum PaymentType
{
    [EnumMember(Value = "Regular")] Regular,
    [EnumMember(Value = "Recurring")] Recurring,
    [EnumMember(Value = "MOTO")] Moto,
    [EnumMember(Value = "Unscheduled")] Unscheduled,
}