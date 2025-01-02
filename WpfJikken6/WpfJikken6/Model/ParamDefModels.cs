using System.Collections;

namespace WpfJikken6.Model
{
    public class ParamDefModels(List<ParamDefModel> items) : IReadOnlyList<ParamDefModel>
    {
        private readonly List<ParamDefModel> _items = items;

        #region Interface Members

        public ParamDefModel this[int index] => _items[index];

        public int Count => _items.Count;

        public IEnumerator<ParamDefModel> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        #endregion Interface Members
    }

    public static class ParamDefModelsExtension
    {
        public static ParamDefModels ToCollection(this List<ParamDefModel> list)
        {
            return new ParamDefModels(list);
        }
    }
}
