namespace WpfJikken6.ValueObject
{
    public class SequentialBytesValue : IBinary
    {
        public byte[] Original { get; }

        public byte[] Modified { get; private set; }

        public SequentialBytesValue(byte[] binary)
        {
            Original = (byte[])binary.Clone();
            Modified = (byte[])binary.Clone();
        }

        public int Int
        {
            get
            {
                int result = 0;

                for (int i = 0; i < Modified.Length; i++)
                    result |= (Modified[i] << (8 * i));

                return result;
            }
        }

        public void SetValue(int value)
        {
            for (int i = 0; i < Modified.Length; i++)
                Modified[i] = (byte)(value >> (8 * i));
        }
    }
}
