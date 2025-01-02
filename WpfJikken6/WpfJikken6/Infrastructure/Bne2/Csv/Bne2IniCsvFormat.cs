using WpfJikken6.Utility;

namespace WpfJikken6.Infrastructure.Bne2.Csv
{
    public class Bne2IniCsvFormat
    {
        [CsvField(1)]
        public string? Address { get; set; }

        [CsvField(2)]
        public string? Name { get; set; }

        [CsvField(3)]
        public string? Size { get; set; }

        [CsvField(4)]
        public string? Step { get; set; }

        [CsvField(5)]
        public string? Row { get; set; }

        [CsvField(6)]
        public string? Disp { get; set; }

        [CsvField(7)]
        public string? Filter { get; set; }

        [CsvField(8)]
        public string? ColWidth { get; set; }

        [CsvField(9)]
        public string? Memo { get; set; }

        [CsvField(10)]
        public string? Items { get; set; }
    }
}
