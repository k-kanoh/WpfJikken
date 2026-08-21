using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WpfJikken2.Base;
using WpfJikken2.DataObject;

namespace WpfJikken2
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial string Title { get; set; } = "メイン画面";

        [ObservableProperty]
        public partial ObservableCollection<ButtonInfo> Buttons { get; set; }

        public MainWindowViewModel(BaseWindow window)
        {
            Buttons =
            [
                new() { Title = "サブ画面1" },
                new() { Title = "サブ画面2" },
                new() { Title = "サブ画面3" }
            ];
        }
    }
}
