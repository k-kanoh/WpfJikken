using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;
using WpfJikken2.Base;

namespace WpfJikken2
{
    public partial class MainWindowViewModel : BaseWindowViewModel
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
            var vm = new SubWindowViewModel(title);
            window.DataContext = vm;
            vm.AccentColors.First(x => x.Name == CurrentAccentColor).ChangeAccentCommand.Execute(CurrentAccentColor);

            window.Owner = mainWindow;
            window.Show();
        }
    }

    public class ButtonInfo
    {
        public required string Title { get; set; }
    }
}
