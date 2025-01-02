using System.IO;
using System.Text.RegularExpressions;
using WpfJikken6.Infrastructure.Bne2.Converter;
using WpfJikken6.Infrastructure.Bne2.Csv;
using WpfJikken6.Poco;

namespace WpfJikken6.Infrastructure.Bne2.Service
{
    public static class Bne2IniLoaderMock
    {
        public static Bne2IniCsvFormats LoadCsv(string path)
        {
            var lines = File.ReadAllLines(path, Util.Shift_JIS);
            var linesWithOutCommentOut = lines.Select(x => Regex.Replace(x, @"//.*$", ""));

            var list = Util.CsvRead<Bne2IniCsvFormat>(linesWithOutCommentOut, true);

            return list.ToCollection();
        }

        public static List<(string, Bne2IniCsvFormat, ParamDef)> LoadAllCsv()
        {
            var path = @"C:\Users\kkano\Desktop\BNE2\Settings";

            var files = new DirectoryInfo(path).GetFiles("*.ini", SearchOption.AllDirectories);

            var list = new List<(string, Bne2IniCsvFormat, ParamDef)>();

            foreach (var file in files)
            {
                var lines = File.ReadAllLines(file.FullName, Util.Shift_JIS);
                var linesWithOutCommentOut = lines.Select(x => Regex.Replace(x, @"//.*$", ""));

                var iniData = Util.CsvRead<Bne2IniCsvFormat>(linesWithOutCommentOut, true);

                var putItem = iniData.Select(x => (file.FullName, x, ParamDefConverter.Transform(x)));

                list.AddRange(putItem);
            }

            return list;
        }
    }
}
