using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfJikken1
{
    public static class FrozenCellHighlight
    {
        public static void ApplyTo(Style cellStyle)
        {
            var isFrozenBinding = new MultiBinding { Converter = new FrozenColumnComparer() };
            isFrozenBinding.Bindings.Add(new Binding("Column.DisplayIndex") { RelativeSource = RelativeSource.Self });
            isFrozenBinding.Bindings.Add(
                new Binding("FrozenColumnCount") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGrid), 1) }
            );

            var frozenTrigger = new DataTrigger { Binding = isFrozenBinding, Value = true };
            frozenTrigger.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.Lavender));
            cellStyle.Triggers.Add(frozenTrigger);

            var selectedTrigger = new Trigger { Property = DataGridCell.IsSelectedProperty, Value = true };
            selectedTrigger.Setters.Add(new Setter(Control.BackgroundProperty, SystemColors.HighlightBrush));
            selectedTrigger.Setters.Add(new Setter(Control.ForegroundProperty, SystemColors.HighlightTextBrush));
            cellStyle.Triggers.Add(selectedTrigger);
        }
    }
}
