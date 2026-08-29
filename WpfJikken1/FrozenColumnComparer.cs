using System.Globalization;
using System.Windows.Data;

namespace WpfJikken1
{
    // Column.DisplayIndexとDataGrid.FrozenColumnCountを比較し、Frozenの範囲内の列かどうかを判定する。
    public class FrozenColumnComparer : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values is [int displayIndex, int frozenColumnCount])
                return displayIndex < frozenColumnCount;
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object? parameter, CultureInfo culture) => throw new NotSupportedException();
    }
}
