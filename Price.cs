public struct Price
{
    private decimal Value { get; }

    public Price(string value)
    {
        string normalizedValue = value.Replace(",", ".").Replace(".", string.Empty);
        if (!decimal.TryParse(normalizedValue, out var parsedValue) || parsedValue < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Invalid price value");
        }

        Value = parsedValue;
    }

    public decimal GetValue()
    {
        return Value;
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
