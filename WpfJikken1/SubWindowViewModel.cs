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

        [ObservableProperty]
        public partial ObservableCollection<string> ComboBoxItems { get; set; }

        public SubWindowViewModel(string windowTitle)
        {
            Title = windowTitle;

            ComboBoxItems =
            [
                "やくそう",
                "どくけしそう",
                "キメラのつばさ"
            ];

            GridItems =
            [
                new() { Name = "項目1", Text = "テキスト1", IsSelected = true, Type = "やくそう" },
                new() { Name = "項目2", Text = "テキスト2", IsSelected = false, Type = "どくけしそう" },
                new() { Name = "項目3", Text = "テキスト3", IsSelected = true, Type = "キメラのつばさ" }
            ];
        }
    }

    public class DataObject
    {
        public required string Name { get; set; }
        public required string Text { get; set; }
        public bool IsSelected { get; set; }
        public required string Type { get; set; }
    }
}
