namespace WpfJikken6.ValueObject
{
    public class CompositeBytesValue : IBinary
    {
        public byte[] Original { get; }

        public byte[] Modified { get; private set; }

        public BitPos BitPos { get; }

        public CompositeBytesValue(byte[] binary, string? pattern = null)
        {
            Original = (byte[])binary.Clone();
            Modified = (byte[])binary.Clone();

            if (pattern != null)
            {
                BitPos = new BitPos(pattern);
            }
            else
            {
                BitPos = BitPos.GetDefault(binary.Length);
            }
        }

        public int Int => BitPos.GetValueFromByteArray(Modified);

        public void SetValue(int value)
        {
            var bytes = BitPos.GetLayoutedByteArray(value);

            for (int i = 0; i < Modified.Length; i++)
            {
                var mod = (Modified[i] & ~BitPos.Bytes[i]) | bytes[i];
                Modified[i] = (byte)mod;
            }
        }
    }
}
