using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Input;

namespace WpfJikken1
{
    public class WindowKeyBindingBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            var closeBinding = new KeyBinding
            {
                Key = Key.W,
                Modifiers = ModifierKeys.Control,
                Command = WindowCommands.Close,
                CommandParameter = AssociatedObject
            };

            AssociatedObject.InputBindings.Add(closeBinding);
        }
    }
}
