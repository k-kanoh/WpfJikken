namespace WpfJikken6.ValueObject
{
    public record BitPos
    {
        private readonly byte[] _bytes;

        private BitPos(int size)
        {
            _bytes = Enumerable.Repeat((byte)0xFF, size).ToArray();
        }

        public BitPos(string pattern)
        {
            Util.ThrowIfInvalidBitPattern(pattern);

            _bytes = new byte[pattern.Length / 8];

            for (int i = 0; i < pattern.Length / 8; i++)
                _bytes[i] = Convert.ToByte(pattern.Substring(i * 8, 8), 2);
        }

        public static BitPos GetDefault(int size)
        {
            return new BitPos(size);
        }

        public byte[] Bytes => _bytes;

        public string[] Patterns => _bytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();

        /// <summary>
        /// ビットパターンの1が立っている位置に値をセットします。
        /// 例：BitPos("11000000") << 3 = 0xC0
        /// </summary>
        public int[] GetLayoutedByteArray(int value)
        {
            var resArray = new int[_bytes.Length];
            int bitOfValue = 0;

            for (int i = _bytes.Length - 1; i >= 0; i--)
            {
                int res = 0;
                for (int j = 0; j < 8; j++)
                {
                    if ((_bytes[i] & (1 << j)) != 0)
                    {
                        if ((value & (1 << bitOfValue)) != 0)
                            res |= (1 << j);

                        bitOfValue++;
                    }
                }

                resArray[i] = res;
            }

            return resArray;
        }

        /// <summary>
        /// ビットパターンの1が立っている位置に値をセットします。
        /// 例：BitPos("11000000") << 3 = 0xC0
        /// </summary>
        public int GetLayoutedByte(int value)
        {
            int result = 0;
            int bitOfValue = 0;

            for (int i = 0; i < 8; i++)
            {
                if ((_bytes[0] & (1 << i)) != 0)
                {
                    if ((value & (1 << bitOfValue)) != 0)
                        result |= (1 << i);

                    bitOfValue++;
                }
            }

            return result;
        }

        /// <summary>
        /// ビットパターンと値の論理積を下位ビットから順に取り出します。
        /// 例：BitPos("11000000") & 0xFF = 3
        /// </summary>
        public int GetValueFromByteArray(byte[] values)
        {
            int result = 0;
            int additional = 1;

            for (int i = _bytes.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((_bytes[i] & (1 << j)) != 0)
                    {
                        if ((values[i] & (1 << j)) != 0)
                            result += additional;

                        additional *= 2;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// ビットパターンと値の論理積を下位ビットから順に取り出します。
        /// 例：BitPos("11000000") & 0xFF = 3
        /// </summary>
        public int GetValueFromByte(int value)
        {
            int result = 0;
            int additional = 1;

            for (int i = 0; i < 8; i++)
            {
                if ((_bytes[0] & (1 << i)) != 0)
                {
                    if ((value & (1 << i)) != 0)
                        result += additional;

                    additional *= 2;
                }
            }

            return result;
        }
    }
}
