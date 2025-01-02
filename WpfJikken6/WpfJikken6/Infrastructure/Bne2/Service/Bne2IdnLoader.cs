using System.IO;
using System.Text.RegularExpressions;
using WpfJikken6.Infrastructure.Bne2.Csv;
using WpfJikken6.Poco;
using WpfJikken6.ValueObject;

namespace WpfJikken6.Infrastructure.Bne2.Service
{
    public static class Bne2IdnLoader
    {
        public static MasterItems LoadCsv(string path)
        {
            var lines = File.ReadAllLines(path, Util.Shift_JIS);
            var linesWithOutCommentOut = lines.Select(x => Regex.Replace(x, @"//.*$", ""));

            var list = new List<MasterItem>();

            MasterItem? masterItem = null;
            foreach (var line in linesWithOutCommentOut)
            {
                var match = Regex.Match(line, @"^([0-9a-fA-F]+)\s(.*)");

                if (match.Success)
                {
                    masterItem = new MasterItem()
                    {
                        Id = new Hex(match.Groups[1].Value),
                        Name = match.Groups[2].Value
                    };
                }
                else
                {
                    masterItem = new MasterItem()
                    {
                        Id = (masterItem == null) ? new Hex("0") : (masterItem.Id + 1),
                        Name = line
                    };
                }

                list.Add(masterItem);
            }

            return list.ToCollection();
        }

        public static List<(string, MasterItems)> LoadAllCsv()
        {
            var path = @"C:\Users\kkano\Desktop\BNE2\Settings";

            var files = new DirectoryInfo(path).GetFiles("*.idn", SearchOption.AllDirectories);

            return files.Select(x => (x.FullName, LoadCsv(x.FullName))).ToList();
        }
    }
}
