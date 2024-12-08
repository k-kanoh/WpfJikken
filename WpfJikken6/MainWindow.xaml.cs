using System.Windows;
using System.Windows.Controls;
using WpfJikken6.Base;
using WpfJikken6.DataObject;

namespace WpfJikken6
{
    public partial class MainWindow : BaseWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is ButtonInfo info)
            {
                var subWindow = new SubWindow() { ParentWindow = this };
                subWindow.DataContext = new SubWindowViewModel(info.Title);
                subWindow.Show();
            }
        }
    }
}
