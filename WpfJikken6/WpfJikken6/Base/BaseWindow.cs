using System.ComponentModel;
using System.Windows;

namespace WpfJikken6.Base
{
    public partial class BaseWindow : Window
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
