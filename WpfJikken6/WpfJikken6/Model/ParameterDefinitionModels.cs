using System.Collections;

namespace WpfJikken6.Model
{
    public class ParameterDefinitionModels(List<ParameterDefinitionModel> items) : IReadOnlyList<ParameterDefinitionModel>
    {
        private readonly List<ParameterDefinitionModel> _items = items;

        #region Interface Members

        public ParameterDefinitionModel this[int index] => _items[index];

        public int Count => _items.Count;

        public IEnumerator<ParameterDefinitionModel> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        #endregion Interface Members
    }

    public static class GridInfoModelsExtension
    {
        public static ParameterDefinitionModels ToGridInfos(this List<ParameterDefinitionModel> list)
        {
            return new ParameterDefinitionModels(list);
        }
    }
}
