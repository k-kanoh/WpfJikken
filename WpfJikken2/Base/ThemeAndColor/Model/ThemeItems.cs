using ControlzEx.Theming;
using System.Collections;

namespace WpfJikken2.Base.ThemeAndColor
{
    public class ThemeItems : IReadOnlyList<ThemeItem>
    {
        private readonly List<ThemeItem> _list;

        public ThemeItems()
        {
            _list = (from theme in ThemeManager.Current.Themes
                     group theme by theme.BaseColorScheme into g
                     select new ThemeItem(g.First())
                    ).ToList();

            CurrentTheme = "Light";
        }

        public string CurrentTheme
        {
            get
            {
                return _list.Single(x => x.IsSelected).Name;
            }
            set
            {
                _list.ForEach(x => x.IsSelected = false);
                _list.Single(x => x.Name == value).IsSelected = true;
            }
        }

        #region Interface Members

        public ThemeItem this[int index] => _list[index];

        public int Count => _list.Count;

        public IEnumerator<ThemeItem> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

        #endregion Interface Members
    }
}
