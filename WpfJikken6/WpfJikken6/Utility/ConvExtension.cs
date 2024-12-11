using System.Globalization;
using System.Text;

namespace WpfJikken6
{
    public static partial class ConvExtension
    {
        private static readonly char[] HexChars = "0123456789ABCDEF".ToCharArray();

        /// <summary>
        /// Hex -> int
        /// </summary>
        public static int HexToIntBigEndian(this string value)
        {
            return int.Parse(value.AsSpan(), NumberStyles.HexNumber);
        }

        /// <summary>
        /// Hex -> int
        /// </summary>
        public static int HexToIntLittleEndian(this string value)
        {
            var bytes = value.HexToByteArray();
            Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// Hex -> byte
        /// </summary>
        public static byte HexToByte(this string value)
        {
            return byte.Parse(value.AsSpan(), NumberStyles.HexNumber);
        }

        /// <summary>
        /// Hex -> byteArray
        /// </summary>
        public static byte[] HexToByteArray(this string value)
        {
            if (value.Length % 2 == 1)
                value = "0" + value;

            var span = value.AsSpan();
            var bytes = new byte[value.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = byte.Parse(span.Slice(i * 2, 2), NumberStyles.HexNumber);

            return bytes;
        }

        /// <summary>
        /// int -> Hex
        /// </summary>
        public static string ToHexBigEndian(this int value)
        {
            return value.ToString("X2");
        }

        /// <summary>
        /// int -> Hex
        /// </summary>
        public static string ToHexLittleEndian(this int value)
        {
            var bytes = BitConverter.GetBytes(value);
            var hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes.Reverse())
            {
                hex.Append(b.ToString("X2"));
            }
            return hex.ToString();
        }

        /// <summary>
        /// Bin -> int
        /// </summary>
        public static int BinToInt(this string value)
        {
            return Convert.ToInt32(value, 2);
        }

        /// <summary>
        /// Bin -> byte
        /// </summary>
        public static byte BinToByte(this string value)
        {
            return Convert.ToByte(value, 2);
        }

        /// <summary>
        /// byte -> int
        /// </summary>
        public static int ToInt(this byte value)
        {
            return value;
        }

        /// <summary>
        /// byte -> Hex
        /// </summary>
        public static string ToHex(this byte value)
        {
            return string.Create(2, value, (chars, state) =>
            {
                chars[0] = HexChars[state >> 4];
                chars[1] = HexChars[state & 0xF];
            });
        }
    }
}
