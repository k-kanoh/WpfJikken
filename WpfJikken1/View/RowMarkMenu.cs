using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfJikken1.Entity;
using WpfJikken1.Extensions;

namespace WpfJikken1.View
{
    public static class RowMarkMenu
    {
        public static readonly (string Name, Brush Brush)[] Colors =
        [
            ("LightYellow", Brushes.LightYellow),
            ("LightGreen", Brushes.LightGreen),
            ("LightSkyBlue", Brushes.LightSkyBlue),
            ("LightPink", Brushes.LightPink),
            ("Wheat", Brushes.Wheat),
            ("PaleTurquoise", Brushes.PaleTurquoise),
            ("Thistle", Brushes.Thistle),
            ("Khaki", Brushes.Khaki),
            ("Gray", Brushes.Gray),
        ];

        public static ContextMenu Create(Action<IReadOnlyList<PropRow>, string> onMark, Action<IReadOnlyList<PropRow>> onUnmark, Action onClearAll)
        {
            var contextMenu = new ContextMenu();

            var markItem = new MenuItem { Header = "選択行をマーク" };
            foreach (var (name, brush) in Colors)
            {
                var colorItem = new MenuItem
                {
                    Header = name,
                    Icon = new Ellipse
                    {
                        Width = 12,
                        Height = 12,
                        Fill = brush,
                    },
                };
                colorItem.Click += (sender, _) => Resolve(sender, rows => onMark(rows, name));
                markItem.Items.Add(colorItem);
            }
            contextMenu.Items.Add(markItem);

            var unmarkItem = new MenuItem { Header = "選択行をマーク解除" };
            unmarkItem.Click += (sender, _) => Resolve(sender, onUnmark);
            contextMenu.Items.Add(unmarkItem);

            var clearItem = new MenuItem { Header = "マークを全解除" };
            clearItem.Click += (_, _) => onClearAll();
            contextMenu.Items.Add(clearItem);

            return contextMenu;
        }

        private static void Resolve(object? sender, Action<IReadOnlyList<PropRow>> apply)
        {
            if (sender is not MenuItem menuItem)
                return;

            ItemsControl? owner = ItemsControl.ItemsControlFromItemContainer(menuItem);
            while (owner is MenuItem parentMenuItem)
                owner = ItemsControl.ItemsControlFromItemContainer(parentMenuItem);

            if (owner is not ContextMenu { PlacementTarget: DataGridCell { DataContext: PropRow clickedRow } cell })
                return;

            var dataGrid = cell.GetVisualAncestor<DataGrid>();
            if (dataGrid == null)
                return;

            var columnCount = dataGrid.Columns.Count;
            var fullySelectedRows = (from cellInfo in dataGrid.SelectedCells group cellInfo by cellInfo.Item into g where g.Count() == columnCount select g.Key)
                .OfType<PropRow>()
                .ToList();

            if (!fullySelectedRows.Contains(clickedRow))
                return;

            apply(fullySelectedRows);
        }
    }
}
