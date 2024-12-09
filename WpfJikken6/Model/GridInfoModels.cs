using System.Collections;

namespace WpfJikken6.Model
{
    public class GridInfoModels : IReadOnlyList<GridInfoModel>
    {
        private readonly List<GridInfoModel> _items;

        public GridInfoModels(List<GridInfoModel> dataObjects)
        {
            _items = dataObjects;
        }

        #region Interface Members

        public GridInfoModel this[int index] => _items[index];

        public int Count => _items.Count;

        public IEnumerator<GridInfoModel> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        #endregion Interface Members
    }
}
