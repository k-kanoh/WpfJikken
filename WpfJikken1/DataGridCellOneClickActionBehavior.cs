using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfJikken1
{
    public class DataGridCellOneClickActionBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewMouseLeftButtonDown += DataGrid_PreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseDoubleClick += DataGrid_PreviewMouseDoubleClick;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PreviewMouseLeftButtonDown -= DataGrid_PreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseDoubleClick -= DataGrid_PreviewMouseDoubleClick;
            base.OnDetaching();
        }

        private void DataGrid_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is not FrameworkElement element) return;
            if (sender is not DataGrid dataGrid) return;

            var cell = element.GetVisualAncestor<DataGridCell>();
            if (cell == null) return;

            if (!cell.IsEditing)
            {
                cell.Focus();
                dataGrid.BeginEdit();
                cell.UpdateLayout();
            }

            var comboBox = cell.GetVisualDescendant<ComboBox>();
            var textBox = cell.GetVisualDescendant<TextBox>();
            if (comboBox == null || textBox == null) return;

            comboBox.IsDropDownOpen = false;
            comboBox.Visibility = Visibility.Collapsed;
            textBox.Visibility = Visibility.Visible;
            textBox.Focus();
            textBox.SelectAll();
            e.Handled = true;
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

            if (cell.Column is DataGridTemplateColumn)
            {
                if (!cell.IsEditing)
                {
                    cell.Focus();
                    dataGrid.BeginEdit();
                    cell.UpdateLayout();
                }

                var comboBox = cell.GetVisualDescendant<ComboBox>();
                if (comboBox != null && !comboBox.IsDropDownOpen)
                {
                    comboBox.IsDropDownOpen = true;
                    e.Handled = true;
                }
            }
            else if (cell.Column is DataGridCheckBoxColumn)
            {
                if (!cell.IsEditing)
                {
                    cell.Focus();
                    dataGrid.BeginEdit();
                }

                var checkBox = element.GetVisualDescendant<CheckBox>();
                if (checkBox != null)
                {
                    checkBox.IsChecked = !checkBox.IsChecked;
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
