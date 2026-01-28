namespace PaymentProvider.Common;

public static class GlobalMethods
{
    public static TEnum ParseEnum<TEnum>(string value)
        where TEnum : struct
    {
        if (!typeof(TEnum).IsEnum)
            throw new ArgumentException("TEnum must be an enum type.");

        return (TEnum)Enum.Parse(typeof(TEnum), value, ignoreCase: true);
    }
}