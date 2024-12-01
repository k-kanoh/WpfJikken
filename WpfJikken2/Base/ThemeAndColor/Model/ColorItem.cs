using CommunityToolkit.Mvvm.ComponentModel;
using ControlzEx.Theming;
using System.Windows.Media;

namespace WpfJikken2.Base.ThemeAndColor
{
    public partial class ColorItem : ObservableObject
    {
        public string Name { get; set; }
        public Brush Color { get; set; }
        public Brush SelectedBackgroundColor { get; set; }

        [ObservableProperty]
        private bool isSelected;

        public ColorItem(Theme theme)
        {
            Name = theme.ColorScheme;
            Color = theme.ShowcaseBrush;

            var solidBrush = (SolidColorBrush)Color;
            SelectedBackgroundColor = new SolidColorBrush(solidBrush.Color) { Opacity = 0.2 };
        }
    }
}
