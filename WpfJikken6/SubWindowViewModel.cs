using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using WpfJikken6.DataObject;

namespace WpfJikken6
{
    public partial class SubWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description = "ここに説明文を記載します。\n複数行の説明文を記載できます。";

        [ObservableProperty]
        private ObservableCollection<GridInfo> gridItems;

        [ObservableProperty]
        public ObservableCollection<string>? comboBoxItems;

        public SubWindowViewModel(string windowTitle)
        {
            Title = windowTitle;
        }

        public void GenerateSample()
        {
            GridItems = [
                new GridInfo() { Address = "3308", Caption = "Lv" },
                new GridInfo() { Address = "3309", Caption = "Exp", Size = 2 },
                new GridInfo() { Address = "330B", Caption = "素早さ" },
                new GridInfo() { Address = "330C", Caption = "Gold", Index = 2 },
                new GridInfo() { Address = "331A", Caption = "Gold", Filter = "00000011", Index = 1, Disp = EnmDisp.None },
                new GridInfo() { Address = "330D", Caption = "攻撃力" },
                new GridInfo() { Address = "330E", Caption = "守備力" },
                new GridInfo() { Address = "330F", Caption = "HP" },
                new GridInfo() { Address = "3310", Caption = "MP" },
                new GridInfo() { Address = "3311", Caption = "Drop", Filter = "01111111", Disp = EnmDisp.List, Master = "ItemMaster" },
                new GridInfo() { Address = "3312", Caption = "行動1", Filter = "01111111", Disp = EnmDisp.List, Master = "ItemMaster" },
                new GridInfo() { Address = "3313", Caption = "行動2", Filter = "01111111", Disp = EnmDisp.List, Master = "ItemMaster" },
                new GridInfo() { Address = "3314", Caption = "行動3", Filter = "01111111", Disp = EnmDisp.List, Master = "ItemMaster" },
                new GridInfo() { Address = "3315", Caption = "行動4", Filter = "01111111", Disp = EnmDisp.List, Master = "ItemMaster" },
                new GridInfo() { Address = "3316", Caption = "行動5", Filter = "01111111", Disp = EnmDisp.List, Master = "ItemMaster" },
                new GridInfo() { Address = "3317", Caption = "行動6", Filter = "01111111", Disp = EnmDisp.List, Master = "ItemMaster" },
                new GridInfo() { Address = "3318", Caption = "行動7", Filter = "01111111", Disp = EnmDisp.List, Master = "ItemMaster" },
                new GridInfo() { Address = "3319", Caption = "行動8", Filter = "01111111", Disp = EnmDisp.List, Master = "ItemMaster" },
                new GridInfo() { Address = "3312", Caption = "AI", Size = 2, Filter = "1000000010000000", Disp = EnmDisp.List, Master = "判断なし|ターン毎|臨機応変" },
                new GridInfo() { Address = "3314", Caption = "タイプ", Size = 2, Filter = "1000000010000000", Disp = EnmDisp.List, Master = "同率|→18%|8優先|循環" },
                new GridInfo() { Address = "3316", Caption = "行動回数", Size = 2, Filter = "1000000010000000", Disp = EnmDisp.List, Master = "1回(100%)|2回(50%)|3回(25%)|2回(100%)" },
                new GridInfo() { Address = "3318", Caption = "自動回復", Size = 2, Filter = "1000000010000000", Disp = EnmDisp.List, Master = "0|16～23|44～55|90～109" },
                new GridInfo() { Address = "3311", Caption = "集中", Filter = "10000000" },
                new GridInfo() { Address = "331A", Caption = "炎系", Filter = "11000000", Disp = EnmDisp.List, Master = "100%|70%|30%|0%" },
                new GridInfo() { Address = "331A", Caption = "ﾋｬﾄﾞ系", Filter = "00110000", Disp = EnmDisp.List, Master = "100%|70%|30%|0%" },
                new GridInfo() { Address = "331A", Caption = "ﾊﾞｷﾞ系", Filter = "00001100", Disp = EnmDisp.List, Master = "100%|70%|30%|0%" },
            ];
        }
    }
}
