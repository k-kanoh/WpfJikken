using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using WpfJikken6.DataObject;
using WpfJikken6.Service;

namespace WpfJikken6
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private Window mainWindow;

        [ObservableProperty]
        private string title = "メイン画面";

        [ObservableProperty]
        public ObservableCollection<ButtonInfo> buttons;

        public MainWindowViewModel(Window window)
        {
            mainWindow = window;

            buttons =
            [
                new() { Title = "サブ画面1" },
                new() { Title = "サブ画面2" },
                new() { Title = "サブ画面3" }
            ];

            var aaaaa = DQ3MonsterParams.CreateGridData();
        }
    }
}
