using System.Collections;
using WpfJikken6.Model;

namespace WpfJikken6.DataObject
{
    public class GridInfos(List<GridInfo> items) : IReadOnlyList<GridInfo>
    {
        private readonly List<GridInfo> _items = items;

        public GridInfoModels ToModels()
        {
            var models = new List<GridInfoModel>();

            foreach (var item in _items)
            {
                var model = new GridInfoModel() { Address = item.Address, Caption = item.Caption };

                Util.ShallowCopy(item, model);
            }

            return new GridInfoModels(models);
        }

        #region Interface Members

        public GridInfo this[int index] => _items[index];

        public int Count => _items.Count;

        public IEnumerator<GridInfo> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        #endregion Interface Members
    }

    public static class GridInfosExtension
    {
        public static GridInfos ToGridInfos(this List<GridInfo> list)
        {
            return new GridInfos(list);
        }
    }
}
