using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

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
        }

        [RelayCommand]
        private void OpenSubWindow(string title)
        {
            var window = new SubWindow();

            window.Owner = mainWindow;
            window.DataContext = new SubWindowViewModel(title);
            window.Show();
        }
    }

    public class ButtonInfo
    {
        public required string Title { get; set; }
    }
}
