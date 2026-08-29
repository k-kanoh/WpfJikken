using System.Windows;
using System.Windows.Media;

namespace WpfJikken1
{
    public static class VisualTreeHelperExtensions
    {
        public static T? GetVisualAncestor<T>(this DependencyObject element)
            where T : DependencyObject
        {
            while (element != null && !(element is T))
                element = VisualTreeHelper.GetParent(element);

            return element as T;
        }

        public static T? GetVisualDescendant<T>(this DependencyObject element)
            where T : DependencyObject
        {
            if (element == null)
                return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                var child = VisualTreeHelper.GetChild(element, i);
                if (child is T found)
                    return found;

                var descendant = GetVisualDescendant<T>(child);
                if (descendant != null)
                    return descendant;
            }

            return null;
        }
    }
}
