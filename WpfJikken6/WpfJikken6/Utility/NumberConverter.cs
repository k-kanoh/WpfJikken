using System.Globalization;
using WpfJikken6.Utility.Exception;

namespace WpfJikken6.Utility
{
    public class NumberConverter
    {
        /// <summary>
        /// Hex -> Int
        /// </summary>
        public static int HexToInt(string value)
        {
            return int.Parse(value, NumberStyles.HexNumber);
        }

        /// <summary>
        /// Int -> Hex (Big Endian)
        /// </summary>
        public static string IntToHex(int value)
        {
            return value.ToString("X2");
        }

        /// <summary>
        /// Byte -> Int
        /// </summary>
        public static int ByteToInt(byte value, string mask = "11111111")
        {
            ThrowIfInvalidMask(mask);
            return value & Convert.ToByte(mask, 2);
        }

        /// <summary>
        /// Byte -> Hex
        /// </summary>
        public static string ByteToHex(byte value, string mask = "11111111")
        {
            return ByteToInt(value, mask).ToString("X2");
        }

        /// <summary>
        /// ByteArray -> Int (Big Endian)
        /// </summary>
        public static int ByteArrayToInt(byte[] values, string[]? masks = null)
        {
            int result = 0;
            int bitValue = 1;

            masks ??= Enumerable.Repeat("11111111", values.Length).ToArray();

            for (int i = values.Length - 1; i >= 0; i--)
            {
                ThrowIfInvalidMask(masks[i]);
                var mask = Convert.ToByte(masks[i], 2);

                for (int j = 0; j < 8; j++)
                {
                    if ((mask & (1 << j)) != 0)
                    {
                        if ((values[i] & (1 << j)) != 0)
                            result += bitValue;

                        bitValue *= 2;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// ByteArray -> Int (Little Endian)
        /// </summary>
        public static int ByteArrayToIntReverse(byte[] values)
        {
            int result = 0;

            for (int i = 0; i < values.Length; i++)
                result |= (values[i] << (8 * i));

            return result;
        }

        /// <summary>
        /// ByteArray -> Hex
        /// </summary>
        public static string ByteArrayToHex(byte[] values)
        {
            return string.Join("", values.Select(b => b.ToString("X2")));
        }

        private static void ThrowIfInvalidMask(string mask)
        {
            if (mask.Length != 8 || !mask.All(c => c == '0' || c == '1'))
                throw new MaskFormatException();
        }
    }
}
