namespace WpfJikken6.ValueObject
{
    public class SingleByteValue
    {
        public byte Original { get; }

        public byte Modified { get; private set; }

        public BitPos BitPos { get; }

        public SingleByteValue(byte binary, string? pattern = null)
        {
            Original = Modified = binary;

            if (pattern != null)
            {
                BitPos = new BitPos(pattern);
            }
            else
            {
                BitPos = BitPos.GetDefault(1);
            }
        }

        public int Int => BitPos.GetValueFromByte(Modified);

        public void SetValue(int value)
        {
            var mod = (Modified & ~BitPos.Bytes[0]) | BitPos.GetLayoutedByte(value);
            Modified = (byte)mod;
        }
    }
}
