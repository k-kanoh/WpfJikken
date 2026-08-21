using System.Globalization;
using System.Windows.Data;

namespace WpfJikken1
{
    public class HexIntConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var code = value is int i ? i : 0;
            var size = parameter is int p ? p : (parameter is string s && int.TryParse(s, out var ps) ? ps : 1);
            var digits = size * 2;
            return $"0x{code.ToString($"X{digits}")}";
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var text = (value as string)?.Trim() ?? "";
            if (text.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                text = text[2..];

            return int.TryParse(text, NumberStyles.HexNumber, culture, out var code) ? code : 0;
        }
    }
}
