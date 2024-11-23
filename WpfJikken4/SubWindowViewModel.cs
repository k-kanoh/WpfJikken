using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace WpfJikken4
{
    public partial class SubWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description = "ここに説明文を記載します。\n複数行の説明文を記載できます。";

        [ObservableProperty]
        private ObservableCollection<DataObject> gridItems;

        [ObservableProperty]
        public ObservableCollection<string> comboBoxItems;

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
