using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using WpfJikken6.DataObject;

namespace WpfJikken6
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private Window mainWindow;

        [ObservableProperty]
        public partial string Title { get; set; } = "メイン画面";

        [ObservableProperty]
        public partial ObservableCollection<ButtonInfo> Buttons { get; set; }

        public MainWindowViewModel(Window window)
        {
            mainWindow = window;

            Buttons =
            [
                new() { Title = "サブ画面1" },
                new() { Title = "サブ画面2" },
                new() { Title = "サブ画面3" }
            ];
        }
    }
}
