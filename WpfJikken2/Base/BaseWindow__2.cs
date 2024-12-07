using MahApps.Metro.Controls;
using System.ComponentModel;

namespace WpfJikken2.Base
{
    public partial class BaseWindow : MetroWindow
    {
        private readonly HashSet<BaseWindow> _childWindows = [];

        private BaseWindow parentWindow = null!;

        public required BaseWindow ParentWindow
        {
            get => parentWindow;
            init
            {
                parentWindow = value;
                value._childWindows.Add(this);
                Closed += (s, e) => value._childWindows.Remove(this);
                ThemeAndColor = value.ThemeAndColor;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            var children = _childWindows.ToList();
            children.ForEach(x => x.Close());

            if (_childWindows.Count > 0)
                e.Cancel = true;

            base.OnClosing(e);
        }
    }
}
