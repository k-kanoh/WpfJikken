using ControlzEx.Theming;
using System.Collections;

namespace WpfJikken2.Base.ThemeAndColor
{
    public class ColorItems : IReadOnlyList<ColorItem>
    {
        private readonly List<ColorItem> _items;

        public ColorItems()
        {
            _items = (from color in ThemeManager.Current.Themes
                     group color by color.ColorScheme into g
                     orderby g.Key
                     select new ColorItem(g.First())
                    ).ToList();

            CurrentColor = "Crimson";
        }

        public string CurrentColor
        {
            get
            {
                return _items.Single(x => x.IsSelected).Name;
            }
            set
            {
                _items.ForEach(x => x.IsSelected = false);
                _items.Single(x => x.Name == value).IsSelected = true;
            }
        }

        #region Interface Members

        public ColorItem this[int index] => _items[index];

        public int Count => _items.Count;

        public IEnumerator<ColorItem> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        #endregion Interface Members
    }
}
