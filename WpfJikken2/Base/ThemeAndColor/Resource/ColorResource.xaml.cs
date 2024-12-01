using System.Windows;
using System.Windows.Controls;

namespace WpfJikken2.Base.ThemeAndColor
{
    public partial class ColorResource : ResourceDictionary
    {
        public ColorResource()
        {
            InitializeComponent();
        }

        public void OnColorMenuItemClick(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem && menuItem.DataContext is ColorItem colorItem && Window.GetWindow(menuItem) is BaseWindow window)
                window.ChangeColorForWindow(colorItem.Name);
        }
    }
}
