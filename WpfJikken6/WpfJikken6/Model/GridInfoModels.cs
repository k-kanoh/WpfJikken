using System.Collections;

namespace WpfJikken6.Model
{
    public class GridInfoModels(List<GridInfoModel> items) : IReadOnlyList<GridInfoModel>
    {
        private readonly List<GridInfoModel> _items = items;

        #region Interface Members

        public GridInfoModel this[int index] => _items[index];

        public int Count => _items.Count;

        public IEnumerator<GridInfoModel> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        #endregion Interface Members
    }

    public static class GridInfoModelsExtension
    {
        public static GridInfoModels ToGridInfos(this List<GridInfoModel> list)
        {
            return new GridInfoModels(list);
        }
    }
}
