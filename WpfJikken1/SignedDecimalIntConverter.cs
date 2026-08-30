using System.Globalization;
using System.Windows.Data;

namespace WpfJikken1
{
    public class SignedDecimalIntConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var code = value is int i ? i : 0;
            var size = parameter is int p ? p : (parameter is string s && int.TryParse(s, out var ps) ? ps : 1);
            var signBit = 1 << (size * 8 - 1);
            var signed = (code & signBit) != 0 ? code - (signBit << 1) : code;
            return signed.ToString();
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var size = parameter is int p ? p : (parameter is string s && int.TryParse(s, out var ps) ? ps : 1);
            var mask = size >= 4 ? -1 : (1 << (size * 8)) - 1;

            return int.TryParse((value as string)?.Trim(), out var signed) ? signed & mask : 0;
        }
    }
}
