using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfJikken1
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

            Buttons = [new() { Title = "サブ画面1" }, new() { Title = "サブ画面2" }, new() { Title = "サブ画面3" }];
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
