using System.Globalization;
using System.Text.RegularExpressions;
using WpfJikken6.Infrastructure.Bne2.Csv;
using WpfJikken6.Poco;
using WpfJikken6.ValueObject;

namespace WpfJikken6.Infrastructure.Bne2.Converter
{
    public static class ParamDefConverter
    {
        public static ParamDef Transform(Bne2IniCsvFormat csv)
        {
            var def = new ParamDef() { Address = new Hex(csv.Address!), Caption = csv.Name! };

            if (csv.Filter != null)
            {
                var match1 = Regex.Match(csv.Filter.ToUpper(), @"([0-9A-F]+)\|([0-9A-F]+)");

                if (match1.Success)
                {
                    def.Min = match1.Groups[1].Value;
                    def.Max = match1.Groups[2].Value;
                }
                else
                {
                    var match2 = Regex.Match(csv.Filter.ToUpper(), @"\.([0-9A-F]+)");

                    if (match2.Success)
                    {
                        var filter = int.Parse(match2.Groups[1].Value, NumberStyles.HexNumber);
                        var len = match2.Groups[1].Value.Length + 1;
                        def.Bit = Convert.ToString(filter, 2).PadLeft(8 * (len / 2), '0');
                    }
                }
            }

            if (csv.Size == null)
            {
                def.Size = 1;
            }
            else
            {
                var match = Regex.Match(csv.Size, @"\.([0-7])");

                if (match.Success)
                {
                    var bit = 0x80 >> int.Parse(match.Groups[1].Value);
                    def.Bit = Convert.ToString(bit, 2).PadLeft(8, '0');
                }
                else
                {
                    def.Size = int.Parse(csv.Size);
                }
            }

            if (csv.Step == null)
            {
                def.Next = def.Size;
            }
            else
            {
                var match = Regex.Match(csv.Step, @"\.([0-7])");

                if (match.Success)
                {
                    def.NextBit = int.Parse(match.Groups[1].Value);
                }
                else
                {
                    def.Next = int.Parse(csv.Step, NumberStyles.HexNumber);
                }
            }

            switch (csv.Disp)
            {
                case "16":
                    def.Disp = EnmDisp.Hex;
                    break;

                case "-10":
                    def.Disp = EnmDisp.Sin;
                    break;

                case "0" when csv.Items != null:
                    def.Disp = EnmDisp.List;
                    break;

                default:
                    def.Disp = EnmDisp.Dec;
                    break;
            }

            if (csv.Row != null)
            {
                def.Row = int.Parse(csv.Row);
            }

            if (csv.Items != null)
            {
                def.Master = csv.Items;
            }

            if (csv.Memo != null)
            {
                def.Memo = csv.Memo;
            }

            return def;
        }
    }
}
