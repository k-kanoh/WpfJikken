using System.Globalization;
using System.Windows.Data;

namespace WpfJikken1.Converter
{
    public class PropListDisplayConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var code = value is int i ? i : 0;
            if (parameter is IReadOnlyDictionary<int, string> namesByCode && namesByCode.TryGetValue(code, out var name))
                return name;

            return code == 0 ? "" : $"0x{code:X2}";
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
