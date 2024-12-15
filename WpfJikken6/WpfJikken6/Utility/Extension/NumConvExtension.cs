using WpfJikken6.Utility;
using WpfJikken6.ValueObject;

namespace WpfJikken6
{
    public static class NumConvExtension
    {
        /// <summary>
        /// Hex -> Int
        /// </summary>
        public static int ToInt(this string value)
        {
            return NumberConverter.HexToInt(value);
        }

        /// <summary>
        /// Int -> Hex (Big Endian)
        /// </summary>
        public static string ToHex(this int value)
        {
            return NumberConverter.IntToHex(value);
        }

        /// <summary>
        /// Byte -> Int
        /// </summary>
        public static int ToInt(this byte value, BitMask? mask = null)
        {
            return NumberConverter.ByteToInt(value, mask);
        }

        /// <summary>
        /// Byte -> Hex
        /// </summary>
        public static string ToHex(this byte value, BitMask? mask = null)
        {
            return NumberConverter.ByteToHex(value, mask);
        }

        /// <summary>
        /// ByteArray -> Int (Big Endian)
        /// </summary>
        public static int ToInt(this byte[] values, BitMask[]? masks = null)
        {
            return NumberConverter.ByteArrayToInt(values, masks);
        }

        /// <summary>
        /// ByteArray -> Int (Little Endian)
        /// </summary>
        public static int ToIntReverse(this byte[] values)
        {
            return NumberConverter.ByteArrayToIntReverse(values);
        }

        /// <summary>
        /// ByteArray -> Hex
        /// </summary>
        public static string ToHex(this byte[] values)
        {
            return NumberConverter.ByteArrayToHex(values);
        }
    }
}
