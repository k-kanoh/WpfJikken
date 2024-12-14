using System.Collections;
using WpfJikken6.Model;

namespace WpfJikken6.DataObject
{
    public class ParameterDefinitions(List<ParameterDefinition> items) : IReadOnlyList<ParameterDefinition>
    {
        private readonly List<ParameterDefinition> _items = items;

        public ParameterDefinitionModels ToModels()
        {
            var models = new List<ParameterDefinitionModel>();

            foreach (var item in _items)
            {
                var model = new ParameterDefinitionModel() { Address = item.Address, Caption = item.Caption };

                Util.ShallowCopy(item, model);
            }

            return new ParameterDefinitionModels(models);
        }

        #region Interface Members

        public ParameterDefinition this[int index] => _items[index];

        public int Count => _items.Count;

        public IEnumerator<ParameterDefinition> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        #endregion Interface Members
    }

    public static class GridInfosExtension
    {
        public static ParameterDefinitions ToGridInfos(this List<ParameterDefinition> list)
        {
            return new ParameterDefinitions(list);
        }
    }
}
