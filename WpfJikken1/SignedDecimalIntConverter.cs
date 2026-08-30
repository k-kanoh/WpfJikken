using System.Globalization;
using System.Windows.Data;

namespace WpfJikken1
{
    public class SignedDecimalIntConverter : IValueConverter
    {
        private readonly int _size;

        public SignedDecimalIntConverter(int size)
        {
            _size = size;
        }

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var code = value is int i ? i : 0;
            var signBit = 1 << (_size * 8 - 1);
            var signed = (code & signBit) != 0 ? code - (signBit << 1) : code;
            return signed.ToString();
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var mask = _size >= 4 ? -1 : (1 << (_size * 8)) - 1;

            return int.TryParse((value as string)?.Trim(), out var signed) ? signed & mask : 0;
        }
    }
}
