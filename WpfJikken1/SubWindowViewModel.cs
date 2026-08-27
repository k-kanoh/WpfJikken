using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using WpfJikken1.Prop;

namespace WpfJikken1
{
    public partial class SubWindowViewModel : ObservableObject
    {
        // .prop駆動の動的グリッド実験用。実機のパスに直接依存する(実験用の割り切り)。
        private const string PropDir = @"C:\Users\kkano\Program Files\BNE2\bined_project\converted\FF3";
        private const string RomPath = @"C:\Users\kkano\Program Files\BNE2\FF3.nes";
        private const int RomBaseAddress = 0x7CD86;
        private const int RomReadLength = 10;

        private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };

        [ObservableProperty]
        public partial string Title { get; set; }

        [ObservableProperty]
        public partial string Description { get; set; } = "";

        [ObservableProperty]
        public partial ObservableCollection<PropRow> GridItems { get; set; }

        public List<DataGridColumn> Columns { get; }

        public SubWindowViewModel(string windowTitle)
        {
            Title = windowTitle;

            var fields = LoadJson<List<PropField>>(Path.Combine(PropDir, "FF3移動速度.prop"));
            var list = LoadJson<List<PropListEntry>>(Path.Combine(PropDir, "FF3移動速度.list"));

            var itemsByField = new Dictionary<string, List<PropItemOption>>();
            foreach (var field in fields)
            {
                if (field.Master == null)
                    continue;
                var items = LoadJson<List<PropItemEntry>>(Path.Combine(PropDir, field.Master));
                itemsByField[field.Caption] = items.Select(PropItemOption.FromEntry).ToList();
            }

            var data = ReadRomBytes();

            GridItems = PropGridBuilder.BuildRows(fields, list, data, RomBaseAddress);
            Columns = PropGridBuilder.BuildColumns(fields, itemsByField);

            Description = fields.FirstOrDefault()?.Memo ?? "";
        }

        private static byte[] ReadRomBytes()
        {
            using var stream = File.OpenRead(RomPath);
            stream.Seek(RomBaseAddress, SeekOrigin.Begin);
            var buffer = new byte[RomReadLength];
            stream.ReadExactly(buffer);
            return buffer;
        }

        private static T LoadJson<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json, JsonOptions)!;
        }
    }
}
