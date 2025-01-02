using System.Collections;

namespace WpfJikken6.Poco
{
    public class MasterItems(List<MasterItem> items) : IReadOnlyList<MasterItem>
    {
        private readonly List<MasterItem> _items = items;

        #region Interface Members

        public MasterItem this[int index] => _items[index];

        public int Count => _items.Count;

        public IEnumerator<MasterItem> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        #endregion Interface Members
    }

    public static class MasterItemsExtension
    {
        public static MasterItems ToCollection(this List<MasterItem> list)
        {
            return new MasterItems(list);
        }
    }
}
