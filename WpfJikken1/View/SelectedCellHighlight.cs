using System.Windows;
using System.Windows.Controls;

namespace WpfJikken1.View
{
    public static class SelectedCellHighlight
    {
        public static Trigger Create()
        {
            var trigger = new Trigger { Property = DataGridCell.IsSelectedProperty, Value = true };
            trigger.Setters.Add(new Setter(Control.BackgroundProperty, SystemColors.HighlightBrush));
            trigger.Setters.Add(new Setter(Control.ForegroundProperty, SystemColors.HighlightTextBrush));
            return trigger;
        }
    }
}
