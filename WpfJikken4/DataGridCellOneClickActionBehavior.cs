using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfJikken4
{
    public class DataGridCellOneClickActionBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewMouseLeftButtonDown += DataGrid_PreviewMouseLeftButtonDown;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PreviewMouseLeftButtonDown -= DataGrid_PreviewMouseLeftButtonDown;
            base.OnDetaching();
        }

        private void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is not FrameworkElement element) return;
            if (sender is not DataGrid dataGrid) return;

            var cell = element.GetVisualAncestor<DataGridCell>();
            if (cell == null) return;

            var row = DataGridRow.GetRowContainingElement(cell);
            if (row != null)
                dataGrid.SelectedItem = row.Item;

            if (cell.Column is DataGridComboBoxColumn)
            {
                if (!cell.IsEditing)
                {
                    cell.Focus();
                    dataGrid.BeginEdit();
                }

                var comboBox = element.GetVisualDescendant<ComboBox>();
                if (comboBox != null)
                {
                    comboBox.IsDropDownOpen = true;
                    e.Handled = true;
                }
            }
        }
    }

    public static class VisualTreeHelperExtensions
    {
        public static T? GetVisualAncestor<T>(this DependencyObject element) where T : DependencyObject
        {
            while (element != null && !(element is T))
                element = VisualTreeHelper.GetParent(element);

            return element as T;
        }

        public static T? GetVisualDescendant<T>(this DependencyObject element) where T : DependencyObject
        {
            if (element == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                var child = VisualTreeHelper.GetChild(element, i);
                if (child is T found)
                    return found;

                var descendant = GetVisualDescendant<T>(child);
                if (descendant != null)
                    return descendant;
            }

            return null;
        }
    }
}
