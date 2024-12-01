using System.Windows;
using System.Windows.Controls;

namespace WpfJikken2.Base.ThemeAndColor
{
    public partial class ThemeResource : ResourceDictionary
    {
        public ThemeResource()
        {
            InitializeComponent();
        }

        public void OnThemeMenuItemClick(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem && menuItem.DataContext is ThemeItem themeItem && Window.GetWindow(menuItem) is BaseWindow window)
                window.ChangeThemeForApplication(themeItem.Name);
        }
    }
}
