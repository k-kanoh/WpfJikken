using System.Collections;
using WpfJikken6.DataObject;
using WpfJikken6.Model;

namespace WpfJikken6.Service
{
    public class DQ3MonsterParams : IReadOnlyList<ParameterDefinitionModel>
    {
        private readonly List<ParameterDefinitionModel> _items;

        private DQ3MonsterParams(ParameterDefinitionModels models)
        {
            _items = models.ToList();
        }

        public static DQ3MonsterParams CreateGridData()
        {
            var list = new List<ParameterDefinition> {
                new ParameterDefinition(17) { Address = "3308", Caption = "Lv" },
                new ParameterDefinition(17) { Address = "3309", Caption = "Exp", Size = 2 },
                new ParameterDefinition(17) { Address = "330B", Caption = "素早さ" },
                new ParameterDefinition(17) { Address = "330C", Caption = "Gold", Index = 2 },
                new ParameterDefinition(17) { Address = "330D", Caption = "攻撃力", Index = 2  },
                new ParameterDefinition(17) { Address = "330E", Caption = "守備力", Index = 2  },
                new ParameterDefinition(17) { Address = "330F", Caption = "HP", Index = 2  },
                new ParameterDefinition(17) { Address = "3310", Caption = "MP" },
                new ParameterDefinition(17) { Address = "3308", Caption = "回避率", Mask = "11000000", Index = 1, Master = "0.0%|1.6%|3.1%|4.7%|6.3%|7.8%|9.4%|10.9%" },
                new ParameterDefinition(17) { Address = "3311", Caption = "回避率", Mask = "10000000", Index = 2, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = "3311", Caption = "Drop", Mask = "01111111", Master = "Item" },
                new ParameterDefinition(17) { Address = "331E", Caption = "宝率", Mask = "00000111", Master = "100.0%|12.5%|6.3%|3.1%|1.6%|0.8%|0.4%|0.0%" },
                new ParameterDefinition(17) { Address = "3312", Caption = "行動1", Mask = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = "3313", Caption = "行動2", Mask = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = "3314", Caption = "行動3", Mask = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = "3315", Caption = "行動4", Mask = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = "3316", Caption = "行動5", Mask = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = "3317", Caption = "行動6", Mask = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = "3318", Caption = "行動7", Mask = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = "3319", Caption = "行動8", Mask = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = "3312", Caption = "AI", Mask = "10000000", Index = 2, Master = "判断なし|ターン毎|臨機応変" },
                new ParameterDefinition(17) { Address = "3313", Caption = "AI", Mask = "10000000", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = "3314", Caption = "タイプ", Mask = "10000000", Index = 2, Master = "同率|→18%|8優先|循環" },
                new ParameterDefinition(17) { Address = "3315", Caption = "タイプ", Mask = "10000000", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = "3316", Caption = "行動回数", Mask = "10000000", Index = 2, Master = "1回(100%)|2回(50%)|3回(25%)|2回(100%)" },
                new ParameterDefinition(17) { Address = "3317", Caption = "行動回数", Mask = "10000000", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = "3318", Caption = "自動回復", Mask = "10000000", Index = 2, Master = "0|16～23|44～55|90～109" },
                new ParameterDefinition(17) { Address = "3319", Caption = "自動回復", Mask = "10000000", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = "331E", Caption = "集中", Mask = "00001000" },
                new ParameterDefinition(17) { Address = "331A", Caption = "炎系", Mask = "11000000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = "331A", Caption = "ﾋｬﾄﾞ系", Mask = "00110000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = "331A", Caption = "ﾊﾞｷﾞ系", Mask = "00001100", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = "331A", Caption = "Gold", Mask = "00000011", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = "331B", Caption = "ﾃﾞｲﾝ系", Mask = "11000000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = "331B", Caption = "ｻﾞｷ系", Mask = "00110000", Master = "100%|91%|51%|0%" },
                new ParameterDefinition(17) { Address = "331B", Caption = "ﾒｶﾞﾝﾃ", Mask = "00001100", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = "331B", Caption = "攻撃力", Mask = "00000011", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = "331C", Caption = "ﾗﾘﾎｰ", Mask = "11000000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = "331C", Caption = "ﾏﾎﾄｰﾝ", Mask = "00110000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = "331C", Caption = "ﾙｶﾆ系", Mask = "00001100", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = "331C", Caption = "守備力", Mask = "00000011", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = "331D", Caption = "ﾏﾇｰｻ", Mask = "11000000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = "331D", Caption = "ﾏﾎﾄﾗ", Mask = "00110000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = "331D", Caption = "ﾒﾀﾞﾊﾟﾆ", Mask = "00001100", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = "331D", Caption = "HP", Mask = "00000011", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = "331E", Caption = "ﾊﾞｼﾙ･ﾎﾞﾐ", Mask = "11000000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = "331E", Caption = "ﾆﾌﾗﾑ", Mask = "00110000", Master = "100%|70%|30%|0%" },
            };

            return new DQ3MonsterParams(list.ToGridInfos().ToModels());
        }

        #region Interface Members

        public ParameterDefinitionModel this[int index] => _items[index];

        public int Count => _items.Count;

        public IEnumerator<ParameterDefinitionModel> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        #endregion Interface Members
    }
}
