namespace PriceMonitor
{
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

        public Price(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be negative");
            }

            Value = value;
        }

        public Price(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be negative");
            }

            Value = value;
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
}
