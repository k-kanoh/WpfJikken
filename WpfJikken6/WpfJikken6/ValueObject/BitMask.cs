namespace WpfJikken6.ValueObject
{
    public record BitMask
    {
        private readonly string _bin;
        private readonly byte _byte;

        public static BitMask Default { get; } = new BitMask();

        public BitMask()
        {
            _bin = "11111111";
            _byte = 0xFF;
        }

        public BitMask(string mask)
        {
            Util.ThrowIfInvalidMask(mask);

            _bin = mask;
            _byte = Convert.ToByte(mask, 2);
        }

        public static implicit operator string(BitMask obj) => obj._bin;
        public static implicit operator byte(BitMask obj) => obj._byte;
    }
}
