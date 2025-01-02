using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WpfJikken6.Infrastructure.Bne2.Service;

namespace WpfJikken6
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "メイン画面";

        [ObservableProperty]
        public ObservableCollection<ButtonInfo> buttons;

        public MainWindowViewModel()
        {
            var allIdn = Bne2IdnLoader.LoadAllCsv();

            var allIni = Bne2IniLoaderMock.LoadAllCsv();

            var jikken1 = from a in allIni
                          group a by new { a.Item2.Filter } into agroup
                          select agroup;

            Title = "";

            buttons =
            [
                new ButtonInfo() { Title = "サブ画面1" },
                new ButtonInfo() { Title = "サブ画面2" },
                new ButtonInfo() { Title = "サブ画面3" }
            ];
        }
    }
}
