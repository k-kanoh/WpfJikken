using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControlzEx.Theming;
using System.Windows;
using System.Windows.Media;

namespace WpfJikken2.Base
{
    public class AccentColorMenuData : ObservableObject
    {
        private readonly BaseWindowViewModel viewModel;

        public string? Name { get; set; }
        public Brush? ColorBrush { get; set; }

        public Brush? IsSelected
        {
            get
            {
                if ((Name == viewModel.CurrentAccentColor) && ColorBrush is SolidColorBrush solidBrush)
                {
                    return new SolidColorBrush(solidBrush.Color) { Opacity = 0.5 };
                }
                else
                {
                    return new SolidColorBrush(Colors.White);
                }
            }
        }

        public AccentColorMenuData(BaseWindowViewModel vm)
        {
            viewModel = vm;
            ChangeAccentCommand = new RelayCommand<string?>(DoChangeTheme);

            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(BaseWindowViewModel.CurrentAccentColor))
                    OnPropertyChanged(nameof(IsSelected));
            };
        }

        public IRelayCommand<string?> ChangeAccentCommand { get; }

        private void DoChangeTheme(string? name)
        {
            if (name == null) return;

            var window = Application.Current.Windows.OfType<Window>().FirstOrDefault(x => x.DataContext == viewModel);
            if (window != null)
            {
                ThemeManager.Current.ChangeThemeColorScheme(window, name);
                viewModel.CurrentAccentColor = name;
            }
        }
    }

    public class AppThemeMenuData
    {
        public string? Name { get; set; }
        public Brush? ColorBrush { get; set; }
        public Brush? BorderColorBrush { get; set; }

        public AppThemeMenuData()
        {
            ChangeAccentCommand = new RelayCommand<string?>(DoChangeTheme);
        }

        public IRelayCommand<string?> ChangeAccentCommand { get; }

        private void DoChangeTheme(string? name)
        {
            if (name == null) return;

            ThemeManager.Current.ChangeThemeBaseColor(Application.Current, name);

            foreach (Window window in Application.Current.Windows)
            {
                var windowTheme = ThemeManager.Current.DetectTheme(window);
                if (windowTheme != null)
                {
                    var newTheme = ThemeManager.Current.GetTheme(name, windowTheme.ColorScheme);
                    if (newTheme != null)
                        ThemeManager.Current.ChangeTheme(window, newTheme);
                }
            }
        }
    }
}
