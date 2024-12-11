using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WpfJikken6.Model;

namespace WpfJikken6
{
    public partial class SubWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description = "ここに説明文を記載します。\n複数行の説明文を記載できます。";

        [ObservableProperty]
        private ObservableCollection<GridInfoModel> gridItems;

        [ObservableProperty]
        public ObservableCollection<string>? comboBoxItems;

        public SubWindowViewModel(string windowTitle)
        {
            Title = windowTitle;
        }

        public void GenerateSample()
        {
            GridItems = [];
        }
    }
}
