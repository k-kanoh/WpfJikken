using System.Collections;

namespace WpfJikken6.Infrastructure.Bne2.Csv
{
    public class Bne2IniCsvFormats(List<Bne2IniCsvFormat> items) : IReadOnlyList<Bne2IniCsvFormat>
    {
        private readonly List<Bne2IniCsvFormat> _items = items;

        #region Interface Members

        public Bne2IniCsvFormat this[int index] => _items[index];

        public int Count => _items.Count;

        public IEnumerator<Bne2IniCsvFormat> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        #endregion Interface Members
    }

    public static class Bne2IniCsvFormatsExtension
    {
        public static Bne2IniCsvFormats ToCollection(this List<Bne2IniCsvFormat> list)
        {
            return new Bne2IniCsvFormats(list);
        }
    }
}
