using System.Collections;
using WpfJikken6.DataObject;
using WpfJikken6.Model;
using WpfJikken6.ValueObject;

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
                new ParameterDefinition(17) { Address = new Hex("3308"), Caption = "Lv" },
                new ParameterDefinition(17) { Address = new Hex("3309"), Caption = "Exp", Size = 2 },
                new ParameterDefinition(17) { Address = new Hex("330B"), Caption = "素早さ" },
                new ParameterDefinition(17) { Address = new Hex("330C"), Caption = "Gold", Index = 2 },
                new ParameterDefinition(17) { Address = new Hex("330D"), Caption = "攻撃力", Index = 2  },
                new ParameterDefinition(17) { Address = new Hex("330E"), Caption = "守備力", Index = 2  },
                new ParameterDefinition(17) { Address = new Hex("330F"), Caption = "HP", Index = 2  },
                new ParameterDefinition(17) { Address = new Hex("3310"), Caption = "MP" },
                new ParameterDefinition(17) { Address = new Hex("3308"), Caption = "回避率", Bit = "11000000", Index = 1, Master = "0.0%|1.6%|3.1%|4.7%|6.3%|7.8%|9.4%|10.9%" },
                new ParameterDefinition(17) { Address = new Hex("3311"), Caption = "回避率", Bit = "10000000", Index = 2, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = new Hex("3311"), Caption = "Drop", Bit = "01111111", Master = "Item" },
                new ParameterDefinition(17) { Address = new Hex("331E"), Caption = "宝率", Bit = "00000111", Master = "100.0%|12.5%|6.3%|3.1%|1.6%|0.8%|0.4%|0.0%" },
                new ParameterDefinition(17) { Address = new Hex("3312"), Caption = "行動1", Bit = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = new Hex("3313"), Caption = "行動2", Bit = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = new Hex("3314"), Caption = "行動3", Bit = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = new Hex("3315"), Caption = "行動4", Bit = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = new Hex("3316"), Caption = "行動5", Bit = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = new Hex("3317"), Caption = "行動6", Bit = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = new Hex("3318"), Caption = "行動7", Bit = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = new Hex("3319"), Caption = "行動8", Bit = "01111111", Master = "MonsterAction" },
                new ParameterDefinition(17) { Address = new Hex("3312"), Caption = "AI", Bit = "10000000", Index = 2, Master = "判断なし|ターン毎|臨機応変" },
                new ParameterDefinition(17) { Address = new Hex("3313"), Caption = "AI", Bit = "10000000", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = new Hex("3314"), Caption = "タイプ", Bit = "10000000", Index = 2, Master = "同率|→18%|8優先|循環" },
                new ParameterDefinition(17) { Address = new Hex("3315"), Caption = "タイプ", Bit = "10000000", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = new Hex("3316"), Caption = "行動回数", Bit = "10000000", Index = 2, Master = "1回(100%)|2回(50%)|3回(25%)|2回(100%)" },
                new ParameterDefinition(17) { Address = new Hex("3317"), Caption = "行動回数", Bit = "10000000", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = new Hex("3318"), Caption = "自動回復", Bit = "10000000", Index = 2, Master = "0|16～23|44～55|90～109" },
                new ParameterDefinition(17) { Address = new Hex("3319"), Caption = "自動回復", Bit = "10000000", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = new Hex("331E"), Caption = "集中", Bit = "00001000" },
                new ParameterDefinition(17) { Address = new Hex("331A"), Caption = "炎系", Bit = "11000000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = new Hex("331A"), Caption = "ﾋｬﾄﾞ系", Bit = "00110000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = new Hex("331A"), Caption = "ﾊﾞｷﾞ系", Bit = "00001100", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = new Hex("331A"), Caption = "Gold", Bit = "00000011", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = new Hex("331B"), Caption = "ﾃﾞｲﾝ系", Bit = "11000000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = new Hex("331B"), Caption = "ｻﾞｷ系", Bit = "00110000", Master = "100%|91%|51%|0%" },
                new ParameterDefinition(17) { Address = new Hex("331B"), Caption = "ﾒｶﾞﾝﾃ", Bit = "00001100", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = new Hex("331B"), Caption = "攻撃力", Bit = "00000011", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = new Hex("331C"), Caption = "ﾗﾘﾎｰ", Bit = "11000000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = new Hex("331C"), Caption = "ﾏﾎﾄｰﾝ", Bit = "00110000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = new Hex("331C"), Caption = "ﾙｶﾆ系", Bit = "00001100", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = new Hex("331C"), Caption = "守備力", Bit = "00000011", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = new Hex("331D"), Caption = "ﾏﾇｰｻ", Bit = "11000000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = new Hex("331D"), Caption = "ﾏﾎﾄﾗ", Bit = "00110000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = new Hex("331D"), Caption = "ﾒﾀﾞﾊﾟﾆ", Bit = "00001100", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = new Hex("331D"), Caption = "HP", Bit = "00000011", Index = 1, Disp = EnmDisp.None },
                new ParameterDefinition(17) { Address = new Hex("331E"), Caption = "ﾊﾞｼﾙ･ﾎﾞﾐ", Bit = "11000000", Master = "100%|70%|30%|0%" },
                new ParameterDefinition(17) { Address = new Hex("331E"), Caption = "ﾆﾌﾗﾑ", Bit = "00110000", Master = "100%|70%|30%|0%" },
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
