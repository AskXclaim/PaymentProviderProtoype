using System.Runtime.Serialization;

namespace PaymentProvider.Application.enums;

public enum PaymentType
{
    [EnumMember(Value = "Regular")] Regular = 1,
    [EnumMember(Value = "Recurring")] Recurring = 2,
    [EnumMember(Value = "MOTO")] Moto = 3,
    [EnumMember(Value = "Unscheduled")] Unscheduled = 4
}