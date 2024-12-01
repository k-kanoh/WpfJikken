using ControlzEx.Theming;
using System.Collections;

namespace WpfJikken2.Base.ThemeAndColor
{
    public class ThemeItems : IReadOnlyList<ThemeItem>
    {
        private readonly List<ThemeItem> _items;

        public ThemeItems()
        {
            _items = (from theme in ThemeManager.Current.Themes
                     group theme by theme.BaseColorScheme into g
                     select new ThemeItem(g.First())
                    ).ToList();

            CurrentTheme = "Light";
        }

        public string CurrentTheme
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

        public ThemeItem this[int index] => _items[index];

        public int Count => _items.Count;

        public IEnumerator<ThemeItem> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        #endregion Interface Members
    }
}
