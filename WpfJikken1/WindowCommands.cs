using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace WpfJikken1
{
    public static class WindowCommands
    {
        public static ICommand Close { get; } = new RelayCommand<Window>(window => window?.Close());
    }
}
