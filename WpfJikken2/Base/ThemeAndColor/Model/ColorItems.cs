using ControlzEx.Theming;
using System.Collections;

namespace WpfJikken2.Base.ThemeAndColor
{
    public class ColorItems : IReadOnlyList<ColorItem>
    {
        private readonly List<ColorItem> _list;

        public ColorItems()
        {
            _list = (from color in ThemeManager.Current.Themes
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
                return _list.Single(x => x.IsSelected).Name;
            }
            set
            {
                _list.ForEach(x => x.IsSelected = false);
                _list.Single(x => x.Name == value).IsSelected = true;
            }
        }

        #region Interface Members

        public ColorItem this[int index] => _list[index];

        public int Count => _list.Count;

        public IEnumerator<ColorItem> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

        #endregion Interface Members
    }
}
