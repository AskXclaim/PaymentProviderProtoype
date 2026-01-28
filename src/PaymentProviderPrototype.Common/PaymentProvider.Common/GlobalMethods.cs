namespace PaymentProvider.Common;

public static class GlobalMethods
{
    public static TEnum ParseEnum<TEnum>(string value)
        where TEnum : struct, Enum => Enum.Parse<TEnum>(value, true);
}