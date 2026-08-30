using System.Globalization;
using System.Windows.Data;
using WpfJikken1.Dto;

namespace WpfJikken1.Converter
{
    public class PropListDisplayConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var code = value is int i ? i : 0;
            if (parameter is IReadOnlyList<PropItemOption> options)
            {
                var match = options.FirstOrDefault(o => o.Code == code);
                if (match != null)
                    return match.Name;
            }

            return code == 0 ? "" : $"0x{code:X2}";
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
