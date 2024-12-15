namespace WpfJikken6.ValueObject
{
    public record Binary
    {
        public required byte Original { get; init; }

        public byte Modified { get; private set; }

        public required string Mask { get; init; }

        public Binary(byte value, string mask = "11111111")
        {
            Original = Modified = value;
            Mask = mask;
        }

        public Binary(int value, string mask = "11111111")
        {
            Original = Modified = (byte)value;
            Mask = mask;
        }

        public Binary(Hex value, string mask = "11111111")
        {
            Original = Modified = (byte)value;
            Mask = mask;
        }
    }
}
