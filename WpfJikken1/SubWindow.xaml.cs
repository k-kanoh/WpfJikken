using System.Windows;
using System.Windows.Input;

namespace WpfJikken1
{
    public partial class SubWindow : Window
    {
        private GridLength _lastDescriptionRowHeight = new(150);

        public SubWindow()
        {
            InitializeComponent();
            Loaded += SubWindow_Loaded;
            DescriptionSplitter.MouseDoubleClick += DescriptionSplitter_MouseDoubleClick;
        }

        private void SubWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is SubWindowViewModel vm)
            {
                foreach (var column in vm.Columns)
                    PropDataGrid.Columns.Add(column);
            }
        }

        private void DescriptionSplitter_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DescriptionRow.Height.Value > 0)
            {
                _lastDescriptionRowHeight = DescriptionRow.Height;
                DescriptionRow.Height = new GridLength(0);
            }
            else
            {
                DescriptionRow.Height = _lastDescriptionRowHeight;
            }
        }
    }
}
