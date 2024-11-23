﻿using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;

namespace WpfJikken2
{
    public static class WindowCommands
    {
        public static ICommand Close { get; } = new RelayCommand<Window>(window => window?.Close());
    }
}