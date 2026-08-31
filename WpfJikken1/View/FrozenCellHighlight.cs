using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfJikken1.View
{
    public static class FrozenCellHighlight
    {
        public static DataTrigger Create()
        {
            var isFrozenBinding = new MultiBinding { Converter = new FrozenColumnComparer() };
            isFrozenBinding.Bindings.Add(new Binding("Column.DisplayIndex") { RelativeSource = RelativeSource.Self });
            isFrozenBinding.Bindings.Add(
                new Binding("FrozenColumnCount") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGrid), 1) }
            );

            var trigger = new DataTrigger { Binding = isFrozenBinding, Value = true };
            trigger.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.Lavender));
            return trigger;
        }
    }
}
