using CommunityToolkit.Mvvm.ComponentModel;
using ControlzEx.Theming;
using System.Windows.Media;

namespace WpfJikken2.Base.ThemeAndColor
{
    public partial class ThemeItem : ObservableObject
    {
        public string Name { get; set; }
        public Brush Color { get; set; }
        public Brush BorderColor { get; set; }

        [ObservableProperty]
        private bool isSelected;

        public ThemeItem(Theme theme)
        {
            Name = theme.BaseColorScheme;
            Color = (Brush)theme.Resources["MahApps.Brushes.ThemeBackground"];
            BorderColor = (Brush)theme.Resources["MahApps.Brushes.ThemeForeground"];
        }
    }
}
