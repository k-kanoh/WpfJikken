using ControlzEx.Theming;
using MahApps.Metro.Controls;
using System.Windows;
using WpfJikken2.Base.ThemeAndColor;

namespace WpfJikken2.Base
{
    public partial class BaseWindow : MetroWindow
    {
        public ThemeItems Themes { get; } = new ThemeItems();

        public ColorItems Colors { get; } = new ColorItems();

        public void ChangeThemeForApplication(string theme)
        {
            foreach (var window in Application.Current.Windows.OfType<BaseWindow>())
            {
                ThemeManager.Current.ChangeThemeBaseColor(window, theme);
                window.Themes.CurrentTheme = theme;
            }
        }

        public void ChangeColorForWindow(string color)
        {
            ThemeManager.Current.ChangeThemeColorScheme(this, color);
            Colors.CurrentColor = color;
        }

        private string ThemeAndColor
        {
            get
            {
                return ThemeManager.Current.DetectTheme(this)?.Name ?? throw new NullReferenceException();
            }
            set
            {
                ThemeManager.Current.ChangeTheme(this, value);
            }
        }
    }
}
