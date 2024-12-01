using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WpfJikken2.Base;
using WpfJikken2.DataObject;

namespace WpfJikken2
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private BaseWindow mainWindow;

        [ObservableProperty]
        private string title = "メイン画面";

        [ObservableProperty]
        public ObservableCollection<ButtonInfo> buttons;

        public MainWindowViewModel(BaseWindow window)
        {
            mainWindow = window;

            buttons =
            [
                new() { Title = "サブ画面1" },
                new() { Title = "サブ画面2" },
                new() { Title = "サブ画面3" }
            ];
        }

        [RelayCommand]
        private void OpenSubWindow(string title)
        {
            var subWindow = new SubWindow();
            subWindow.Owner = mainWindow;
            subWindow.ThemeAndColor = mainWindow.ThemeAndColor;
            subWindow.DataContext = new SubWindowViewModel(title);
            subWindow.Show();
        }
    }
}
