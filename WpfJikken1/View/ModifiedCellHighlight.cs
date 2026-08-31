using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfJikken1.View
{
    public static class ModifiedCellHighlight
    {
        public static DataTrigger Create(string fieldKey)
        {
            var trigger = new DataTrigger { Binding = new Binding($"IsModified[{fieldKey}]"), Value = true };
            trigger.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.MistyRose));
            trigger.Setters.Add(new Setter(Control.FontWeightProperty, FontWeights.Bold));
            return trigger;
        }
    }
}
