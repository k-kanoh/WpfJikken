using System.IO;
using System.Text.RegularExpressions;
using WpfJikken6.Infrastructure.Bne2.Csv;

namespace WpfJikken6.Infrastructure.Bne2.Service
{
    public static class Bne2IniLoader
    {
        public static Bne2IniCsvFormats LoadCsv(string path)
        {
            var lines = File.ReadAllLines(path, Util.Shift_JIS);
            var linesWithOutCommentOut = lines.Select(x => Regex.Replace(x, @"//.*$", ""));

            var list = Util.CsvRead<Bne2IniCsvFormat>(linesWithOutCommentOut, true);

            return list.ToCollection();
        }
    }
}
