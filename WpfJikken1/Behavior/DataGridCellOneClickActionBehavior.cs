using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;
using WpfJikken1.Entity;
using WpfJikken1.Extensions;

namespace WpfJikken1.Behavior
{
    public class DataGridCellOneClickActionBehavior : Behavior<DataGrid>
    {
        private PropRow? _editingItem;
        private string? _editingFieldKey;
        private int? _originalValue;

        private DataGridRow? _rowHeaderDragAnchor;

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewMouseLeftButtonDown += DataGrid_PreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseLeftButtonUp += DataGrid_PreviewMouseLeftButtonUp;
            AssociatedObject.PreviewMouseMove += DataGrid_PreviewMouseMove;
            AssociatedObject.PreviewMouseDoubleClick += DataGrid_PreviewMouseDoubleClick;
            AssociatedObject.BeginningEdit += DataGrid_BeginningEdit;
            AssociatedObject.CellEditEnding += DataGrid_CellEditEnding;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PreviewMouseLeftButtonDown -= DataGrid_PreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseLeftButtonUp -= DataGrid_PreviewMouseLeftButtonUp;
            AssociatedObject.PreviewMouseMove -= DataGrid_PreviewMouseMove;
            AssociatedObject.PreviewMouseDoubleClick -= DataGrid_PreviewMouseDoubleClick;
            AssociatedObject.BeginningEdit -= DataGrid_BeginningEdit;
            AssociatedObject.CellEditEnding -= DataGrid_CellEditEnding;
            base.OnDetaching();
        }

        // ComboBoxの選択バインディングはUpdateSourceTrigger=PropertyChangedのため、選択した瞬間に
        // 元データへ書き込まれてしまい、Esc(CancelEdit)では戻せない。編集開始前の値を退避しておき、
        // キャンセル時に手動で書き戻す。
        private void DataGrid_BeginningEdit(object? sender, DataGridBeginningEditEventArgs e)
        {
            if (e.Column.SortMemberPath is not string field || e.Row.Item is not PropRow row)
                return;

            _editingItem = row;
            _editingFieldKey = field;
            _originalValue = row[field];
        }

        private void DataGrid_CellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Cancel && _editingItem != null && _editingFieldKey != null)
                _editingItem[_editingFieldKey] = _originalValue!.Value;

            _editingItem = null;
            _editingFieldKey = null;
            _originalValue = null;
        }

        private void DataGrid_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is not FrameworkElement element)
                return;

            var dataGrid = AssociatedObject;
            var cell = element.GetVisualAncestor<DataGridCell>();
            if (cell == null)
                return;

            if (!cell.IsEditing)
            {
                cell.Focus();
                dataGrid.BeginEdit();
                cell.UpdateLayout();
            }

            var comboBox = cell.GetVisualDescendant<ComboBox>();
            var textBox = cell.GetVisualDescendant<TextBox>();
            if (comboBox == null || textBox == null)
                return;

            comboBox.IsDropDownOpen = false;
            comboBox.Visibility = Visibility.Collapsed;
            textBox.Visibility = Visibility.Visible;
            textBox.Focus();
            textBox.SelectAll();
            e.Handled = true;
        }

        private void DataGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is not FrameworkElement element)
                return;

            var dataGrid = AssociatedObject;
            var cell = element.GetVisualAncestor<DataGridCell>();
            if (cell == null)
                return;

            // 疑似行ヘッダー列(先頭列)のクリックは、本来のDataGrid行ヘッダーと同じくその行全体を選択する。
            // cell.Focus()がCurrentCellの更新・編集中セルのコミットを内部で行うため、
            // それらを明示的に呼ぶ必要はない(下のTemplateColumn/CheckBoxColumnの分岐と同様)。
            // マウスを離すまでキャプチャし、ドラッグした範囲の行をまとめて選択できるようにする。
            // 初回選択はCaptureMouse()の副作用で発生するPreviewMouseMoveに任せる。
            if (cell.Column == dataGrid.Columns[0])
            {
                var row = DataGridRow.GetRowContainingElement(cell);
                if (row == null)
                    return;

                cell.Focus();
                _rowHeaderDragAnchor = row;
                dataGrid.CaptureMouse();
                e.Handled = true;
                return;
            }

            // このセル単体が既に選択されている場合のみ編集を開始する。複数選択中の一部を
            // クリックした場合は、raw cellと同じく通常通り選択解除・単一選択されるだけに留める。
            if (dataGrid.SelectedCells.Count != 1 || !cell.IsSelected)
                return;

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

        private void DataGrid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_rowHeaderDragAnchor == null)
                return;

            var dataGrid = AssociatedObject;

            if (e.LeftButton != MouseButtonState.Pressed)
            {
                _rowHeaderDragAnchor = null;
                if (dataGrid.IsMouseCaptured)
                    dataGrid.ReleaseMouseCapture();
                return;
            }

            var element = dataGrid.InputHitTest(e.GetPosition(dataGrid)) as DependencyObject;
            var row = element?.GetVisualAncestor<DataGridRow>();
            if (row != null)
                SelectRowRange(dataGrid, _rowHeaderDragAnchor, row);
        }

        // fromRow・toRow(両端含む)の間にある全行・全セルを選択する。
        private static void SelectRowRange(DataGrid dataGrid, DataGridRow fromRow, DataGridRow toRow)
        {
            int fromIndex = dataGrid.Items.IndexOf(fromRow.Item);
            int toIndex = dataGrid.Items.IndexOf(toRow.Item);
            if (fromIndex < 0 || toIndex < 0)
                return;

            int start = Math.Min(fromIndex, toIndex);
            int end = Math.Max(fromIndex, toIndex);

            dataGrid.SelectedCells.Clear();
            for (int i = start; i <= end; i++)
            {
                var item = dataGrid.Items[i];
                foreach (var column in dataGrid.Columns)
                    dataGrid.SelectedCells.Add(new DataGridCellInfo(item, column));
            }
        }

        private void DataGrid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_rowHeaderDragAnchor == null)
                return;

            _rowHeaderDragAnchor = null;
            if (AssociatedObject.IsMouseCaptured)
                AssociatedObject.ReleaseMouseCapture();
        }
    }
}
