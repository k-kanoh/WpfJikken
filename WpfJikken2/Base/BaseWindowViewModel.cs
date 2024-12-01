using CommunityToolkit.Mvvm.ComponentModel;
using ControlzEx.Theming;
using System.Windows.Media;

namespace WpfJikken2.Base
{
    public partial class BaseWindowViewModel : ObservableObject
    {
        public List<AccentColorMenuData> AccentColors { get; }
        public List<AppThemeMenuData> AppThemes { get; }

        [ObservableProperty]
        private string currentAccentColor = "Crimson";

        public BaseWindowViewModel()
        {
            AccentColors = (from theme in ThemeManager.Current.Themes
                            group theme by theme.ColorScheme into grouped
                            orderby grouped.Key
                            select new AccentColorMenuData(this)
                            {
                                Name = grouped.Key,
                                ColorBrush = grouped.First().ShowcaseBrush
                            }).ToList();

            AppThemes = (from theme in ThemeManager.Current.Themes
                         group theme by theme.BaseColorScheme into grouped
                         select grouped.First() into firstTheme
                         select new AppThemeMenuData()
                         {
                             Name = firstTheme.BaseColorScheme,
                             BorderColorBrush = firstTheme.Resources["MahApps.Brushes.ThemeForeground"] as Brush,
                             ColorBrush = firstTheme.Resources["MahApps.Brushes.ThemeBackground"] as Brush
                         }).ToList();
        }
    }
}
