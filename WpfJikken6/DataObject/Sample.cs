using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfJikken6.DataObject
{
    public partial class Sample : ObservableObject
    {
        public required string Name { get; set; }
        public required string Text { get; set; }
        public required bool IsSelected { get; set; }

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
