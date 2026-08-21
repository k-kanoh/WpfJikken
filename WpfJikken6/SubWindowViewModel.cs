using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WpfJikken6.DataObject;

namespace WpfJikken6
{
    public partial class SubWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial string Title { get; set; }

        [ObservableProperty]
        public partial string Description { get; set; } = "ここに説明文を記載します。\n複数行の説明文を記載できます。";

        [ObservableProperty]
        public partial ObservableCollection<Sample> GridItems { get; set; }

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
}
