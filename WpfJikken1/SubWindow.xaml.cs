using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using WpfJikken1.View;

namespace WpfJikken1
{
    public partial class SubWindow : Window
    {
        private GridLength _lastDescriptionRowHeight = new(150);

        public SubWindow()
        {
            InitializeComponent();
            Loaded += SubWindow_Loaded;
            DescriptionSplitter.MouseDoubleClick += DescriptionSplitter_MouseDoubleClick;
        }

        private void SubWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is SubWindowViewModel vm)
            {
                foreach (var column in vm.Columns)
                    PropDataGrid.Columns.Add(column);

                RowHeaderColumn.CellStyle = BuildRowHeaderCellStyle(vm);
            }

            PropDataGrid.ColumnReordering += PropDataGrid_ColumnReordering;
            PropDataGrid.ColumnHeaderStyle = BuildColumnHeaderStyle();
        }

        private void PropDataGrid_ColumnReordering(object? sender, DataGridColumnReorderingEventArgs e)
        {
            if (e.Column.DisplayIndex < PropDataGrid.FrozenColumnCount)
                e.Cancel = true;
        }

        // XAML上のStyle.Setter.Value内にContextMenuとClickハンドラを書くとイベント接続に失敗するため、
        // 列ヘッダーのStyle(フォント+右クリックメニュー)自体をコードビハインドで組み立てる。
        private Style BuildColumnHeaderStyle()
        {
            var freezeItem = new MenuItem { Header = "この列まで固定" };
            freezeItem.Click += (sender, _) =>
            {
                var menuItem = (MenuItem)sender;
                if (menuItem.Parent is not ContextMenu contextMenu)
                    return;
                if (contextMenu.PlacementTarget is not DataGridColumnHeader header)
                    return;
                if (header.Column is not { } column)
                    return;

                PropDataGrid.FrozenColumnCount = column.DisplayIndex + 1;
            };

            var unfreezeItem = new MenuItem { Header = "固定を解除" };
            unfreezeItem.Click += (_, _) => PropDataGrid.FrozenColumnCount = 1;

            var contextMenu = new ContextMenu();
            contextMenu.Items.Add(freezeItem);
            contextMenu.Items.Add(unfreezeItem);

            var style = new Style(typeof(DataGridColumnHeader));
            style.Setters.Add(new Setter(Control.FontFamilyProperty, new FontFamily("Segoe UI")));
            style.Setters.Add(new Setter(FrameworkElement.ContextMenuProperty, contextMenu));
            return style;
        }

        private Style BuildRowHeaderCellStyle(SubWindowViewModel vm)
        {
            var style = new Style(typeof(DataGridCell));
            style.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(0)));
            style.Setters.Add(
                new Setter(
                    Control.ForegroundProperty,
                    new Binding("Foreground") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGrid), 1) }
                )
            );
            style.Setters.Add(
                new Setter(
                    Control.BackgroundProperty,
                    new Binding("Background") { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGrid), 1) }
                )
            );
            style.Setters.Add(new Setter(FrameworkElement.ContextMenuProperty, RowMarkMenu.Create(vm.MarkRows, vm.UnmarkRows, vm.ClearAllMarks)));
            return style;
        }

        private void DescriptionSplitter_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DescriptionRow.Height.Value > 0)
            {
                _lastDescriptionRowHeight = DescriptionRow.Height;
                DescriptionRow.Height = new GridLength(0);
            }
            else
            {
                DescriptionRow.Height = _lastDescriptionRowHeight;
            }
        }
    }
}
