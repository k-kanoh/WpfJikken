using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace WpfJikken1.Prop
{
    // .prop/.list/.items と生バイト列から、DataGridの行と列(DataGridTemplateColumn)を
    // 実行時に組み立てるコア処理。1つの.propに複数フィールドがある場合も想定し、
    // フィールドごとに行数(count)・有効/無効を個別に判定する。
    public static class PropGridBuilder
    {
        public static ObservableCollection<PropRow> BuildRows(IReadOnlyList<PropField> fields, IReadOnlyList<PropListEntry> list, byte[] data)
        {
            var rows = new ObservableCollection<PropRow>();

            for (int i = 0; i < list.Count; i++)
            {
                var row = new PropRow { Header = list[i].Name ?? $"#{list[i].Id}" };

                foreach (var field in fields)
                {
                    // countが無ければreadme.txt仕様通り.listの件数がデフォルト行数。
                    var fieldRowCount = field.Count ?? list.Count;
                    var enabled = i < fieldRowCount;
                    row.FieldEnabled[field.Caption] = enabled;

                    if (enabled)
                    {
                        var step = field.Step ?? field.Size;
                        var offset = field.Address + i * step;
                        row[field.Caption] = ReadValue(data, offset, field);
                    }
                }

                rows.Add(row);
            }

            return rows;
        }

        private static int ReadValue(byte[] data, int offset, PropField field)
        {
            int value = 0;
            for (int b = 0; b < field.Size; b++)
                value = (value << 8) | data[offset + b];

            if (field.BitPattern != null)
                value &= Convert.ToInt32(field.BitPattern, 2);

            return value;
        }

        public static List<DataGridColumn> BuildColumns(IReadOnlyList<PropField> fields, IReadOnlyDictionary<string, List<PropItemOption>> itemsByField)
        {
            var columns = new List<DataGridColumn>();

            foreach (var field in fields)
            {
                columns.Add(
                    field.Display switch
                    {
                        "list" => BuildListColumn(field, itemsByField.GetValueOrDefault(field.Caption) ?? []),
                        _ => BuildRawColumn(field),
                    }
                );
            }

            return columns;
        }

        private static DataGridTemplateColumn BuildListColumn(PropField field, List<PropItemOption> options)
        {
            var displayConverter = new PropListDisplayConverter();

            var cellFactory = new FrameworkElementFactory(typeof(TextBlock));
            cellFactory.SetValue(TextBlock.PaddingProperty, new Thickness(4, 0, 4, 0));
            cellFactory.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            cellFactory.SetBinding(TextBlock.TextProperty, new Binding($"[{field.Caption}]") { Converter = displayConverter, ConverterParameter = options });
            var cellTemplate = new DataTemplate { VisualTree = cellFactory };

            var gridFactory = new FrameworkElementFactory(typeof(Grid));

            var comboFactory = new FrameworkElementFactory(typeof(ComboBox), "ComboEditor");
            comboFactory.SetValue(ComboBox.DisplayMemberPathProperty, nameof(PropItemOption.DisplayLabel));
            comboFactory.SetValue(ComboBox.SelectedValuePathProperty, nameof(PropItemOption.Code));
            comboFactory.SetValue(ItemsControl.ItemsSourceProperty, options);
            comboFactory.SetValue(ComboBox.IsDropDownOpenProperty, true);
            comboFactory.SetBinding(
                Selector.SelectedValueProperty,
                new Binding($"[{field.Caption}]") { Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged }
            );
            gridFactory.AppendChild(comboFactory);

            var textFactory = new FrameworkElementFactory(typeof(TextBox), "TextEditor");
            textFactory.SetValue(UIElement.VisibilityProperty, Visibility.Collapsed);
            textFactory.SetBinding(
                TextBox.TextProperty,
                new Binding($"[{field.Caption}]")
                {
                    Mode = BindingMode.TwoWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.LostFocus,
                    Converter = new HexIntConverter(),
                    ConverterParameter = field.Size,
                }
            );
            gridFactory.AppendChild(textFactory);

            var editingTemplate = new DataTemplate { VisualTree = gridFactory };

            var cellStyle = new Style(typeof(DataGridCell));
            cellStyle.Setters.Add(new Setter(UIElement.IsEnabledProperty, new Binding($"FieldEnabled[{field.Caption}]")));

            return new DataGridTemplateColumn
            {
                Header = field.Caption,
                Width = new DataGridLength(160),
                CellTemplate = cellTemplate,
                CellEditingTemplate = editingTemplate,
                CellStyle = cellStyle,
            };
        }

        // list以外のdisplay(hex/decimal/signedDecimal)は今回未検証。生値をhexで直接編集するだけの最小実装。
        private static DataGridColumn BuildRawColumn(PropField field)
        {
            var cellStyle = new Style(typeof(DataGridCell));
            cellStyle.Setters.Add(new Setter(UIElement.IsEnabledProperty, new Binding($"FieldEnabled[{field.Caption}]")));

            return new DataGridTextColumn
            {
                Header = field.Caption,
                Width = new DataGridLength(120),
                CellStyle = cellStyle,
                Binding = new Binding($"[{field.Caption}]")
                {
                    Mode = BindingMode.TwoWay,
                    Converter = new HexIntConverter(),
                    ConverterParameter = field.Size,
                },
            };
        }
    }
}
