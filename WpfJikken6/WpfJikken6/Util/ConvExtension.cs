using System.Globalization;

namespace WpfJikken6
{
    public static partial class ConvExtension
    {
        private static readonly char[] HexChars = "0123456789ABCDEF".ToCharArray();

        /// <summary>
        /// Hex -> int
        /// </summary>
        public static int HexToInt(this string value)
        {
            return int.Parse(value.AsSpan(), NumberStyles.HexNumber);
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
        public static byte[] HexToByteArrayBigEndian(this string value)
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
        /// Hex -> byteArray
        /// </summary>
        public static byte[] HexToByteArrayLittleEndian(this string value)
        {
            if (value.Length % 2 == 1)
                value = "0" + value;

            var span = value.AsSpan();
            var bytes = new byte[value.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
                bytes[bytes.Length - i - 1] = byte.Parse(span.Slice(i * 2, 2), NumberStyles.HexNumber);

            return bytes;
        }

        /// <summary>
        /// int -> Hex
        /// </summary>
        public static string ToHex(this int value)
        {
            return value.ToString("X2");
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
