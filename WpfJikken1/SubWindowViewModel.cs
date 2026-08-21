using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace WpfJikken1
{
    public partial class SubWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial string Title { get; set; }

        [ObservableProperty]
        public partial string Description { get; set; } = "ここに説明文を記載します。\n複数行の説明文を記載できます。";

        [ObservableProperty]
        public partial ObservableCollection<DataObject> GridItems { get; set; }

        public ObservableCollection<ItemMasterEntry> ComboBoxItems => ItemMaster.Entries;

        public SubWindowViewModel(string windowTitle)
        {
            Title = windowTitle;

            GridItems =
            [
                new() { Name = "項目1", Text = "テキスト1", IsSelected = true, ItemCode = 0x01 },
                new() { Name = "項目2", Text = "テキスト2", IsSelected = false, ItemCode = 0x09 },
                new() { Name = "項目3", Text = "テキスト3", IsSelected = true, ItemCode = 0x9999 }
            ];
        }
    }

    public partial class DataObject : ObservableObject
    {
        public required string Name { get; set; }
        public required string Text { get; set; }
        public bool IsSelected { get; set; }

        [ObservableProperty]
        public partial int ItemCode { get; set; }

        // 1バイト(size=1)想定。桁数はpropのsizeに合わせて可変にする必要がある
        public string DisplayText => ItemMaster.TryGetName(ItemCode, out var name) ? name : $"0x{ItemCode:X2}";

        partial void OnItemCodeChanged(int value)
        {
            OnPropertyChanged(nameof(DisplayText));
        }
    }
}
