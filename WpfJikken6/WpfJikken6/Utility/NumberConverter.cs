using System.Globalization;
using System.Text;

namespace WpfJikken6.Utility
{
    public class NumberConverter
    {
        private static readonly char[] HexChars = "0123456789ABCDEF".ToCharArray();

        /// <summary>
        /// Hex -> int
        /// </summary>
        public static int HexToIntBigEndian(string value)
        {
            return int.Parse(value, NumberStyles.HexNumber);
        }

        /// <summary>
        /// Hex -> int
        /// </summary>
        public static int HexToIntLittleEndian(string value)
        {
            var bytes = HexToByteArray(value);
            Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// Hex -> byte
        /// </summary>
        public static byte HexToByte(string value)
        {
            return byte.Parse(value, NumberStyles.HexNumber);
        }

        /// <summary>
        /// Hex -> byteArray
        /// </summary>
        public static byte[] HexToByteArray(string value)
        {
            if (value.Length % 2 == 1)
                value = "0" + value;

            var bytes = new byte[value.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = byte.Parse(value.Substring(i * 2, 2), NumberStyles.HexNumber);

            return bytes;
        }

        /// <summary>
        /// int -> Hex
        /// </summary>
        public static string ToHexBigEndian(int value)
        {
            return value.ToString("X2");
        }

        /// <summary>
        /// int -> Hex
        /// </summary>
        public static string ToHexLittleEndian(int value)
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
        public static int BinToInt(string value)
        {
            return Convert.ToInt32(value, 2);
        }

        /// <summary>
        /// Bin -> byte
        /// </summary>
        public static byte BinToByte(string value)
        {
            return Convert.ToByte(value, 2);
        }

        /// <summary>
        /// byte -> int
        /// </summary>
        public static int ToInt(byte value)
        {
            return value;
        }

        /// <summary>
        /// byte -> Hex
        /// </summary>
        public static string ToHex(byte value)
        {
            return string.Create(2, value, (chars, state) =>
            {
                chars[0] = HexChars[state >> 4];
                chars[1] = HexChars[state & 0xF];
            });
        }
    }
}
