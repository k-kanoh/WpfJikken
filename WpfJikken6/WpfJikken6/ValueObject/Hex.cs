using System.Globalization;
using WpfJikken6.Utility.Exception;

namespace WpfJikken6.ValueObject
{
    public record Hex
    {
        private readonly string _hex;
        private readonly int _int;

        private Hex(int value)
        {
            _hex = value.ToString("X2");
            _int = value;
        }

        public Hex(string hex)
        {
            if (!uint.TryParse(hex, NumberStyles.HexNumber, null, out _))
                throw new HexFormatException();

            _hex = hex.ToUpper();
            _int = int.Parse(hex, NumberStyles.HexNumber);
        }

        public static Hex operator +(Hex obj, int value) => new(obj._int + value);
        public static Hex operator -(Hex obj, int value) => new(obj._int - value);

        public static implicit operator string(Hex obj) => obj._hex;
        public static implicit operator int(Hex obj) => obj._int;

        public static explicit operator byte(Hex obj) => (byte)obj._int;
    }
}
