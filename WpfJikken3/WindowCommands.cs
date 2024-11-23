using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;

namespace WpfJikken3
{
    public static class WindowCommands
    {
        public static ICommand Close { get; } = new RelayCommand<Window>(window => window?.Close());
    }
}
