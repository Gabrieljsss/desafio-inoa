public struct Price
{
    public decimal Value { get; }

    public Price(string value)
    {
        string normalizedValue = value.Replace(",", ".").Replace(".", string.Empty);
        if (!decimal.TryParse(normalizedValue, out var parsedValue) || parsedValue < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Invalid price value");
        }

        Value = parsedValue;
    }

    public bool LessOrEquals(Price other)
    {
        return Value <= other.Value;
    }

    public bool GreaterOrEquals(Price other)
    {
        return Value >= other.Value;
    }
}
