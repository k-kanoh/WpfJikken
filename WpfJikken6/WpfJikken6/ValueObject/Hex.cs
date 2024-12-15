using System.Globalization;
using WpfJikken6.Utility.Exception;

namespace WpfJikken6.ValueObject
{
    public record Hex
    {
        private readonly string _hex;
        private readonly int _int;

        public Hex(string hex)
        {
            if (!uint.TryParse(hex, NumberStyles.HexNumber, null, out _))
                throw new HexFormatException();

            _hex = hex;
            _int = hex.ToInt();
        }

        public static implicit operator string(Hex obj) => obj._hex;
        public static implicit operator int(Hex obj) => obj._int;
    }
}
