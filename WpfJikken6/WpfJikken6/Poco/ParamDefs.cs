using System.Collections;

namespace WpfJikken6.Poco
{
    public class ParamDefs(List<ParamDef> items) : IReadOnlyList<ParamDef>
    {
        private readonly List<ParamDef> _items = items;

        #region Interface Members

        public ParamDef this[int index] => _items[index];

        public int Count => _items.Count;

        public IEnumerator<ParamDef> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        #endregion Interface Members
    }

    public static class ParamDefsExtension
    {
        public static ParamDefs ToCollection(this List<ParamDef> list)
        {
            return new ParamDefs(list);
        }
    }
}
