using System.Windows;

namespace WpfJikken1
{
    public partial class SubWindow : Window
    {
        public SubWindow()
        {
            InitializeComponent();
            Loaded += SubWindow_Loaded;
        }

        private void SubWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is SubWindowViewModel vm)
            {
                foreach (var column in vm.Columns)
                    PropDataGrid.Columns.Add(column);
            }
        }
    }
}
