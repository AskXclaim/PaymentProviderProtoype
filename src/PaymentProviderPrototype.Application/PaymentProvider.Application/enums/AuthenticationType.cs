using System.Runtime.Serialization;

namespace PaymentProvider.Application.enums;

public enum AuthenticationType
{
    [EnumMember(Value = "3ds")] ThreeDSecure=1,
    [EnumMember(Value = "google_spa")] GoogleSpa=2
}