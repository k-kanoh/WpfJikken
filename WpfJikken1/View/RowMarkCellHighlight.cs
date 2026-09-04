using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfJikken1.Converter;

namespace WpfJikken1.View
{
    public static class RowMarkCellHighlight
    {
        public static DataTrigger Create()
        {
            var trigger = new DataTrigger
            {
                Binding = new Binding("MarkBrush") { Converter = new NotNullConverter() },
                Value = true,
            };
            trigger.Setters.Add(new Setter(Control.BackgroundProperty, new Binding("MarkBrush")));
            return trigger;
        }
    }
}
