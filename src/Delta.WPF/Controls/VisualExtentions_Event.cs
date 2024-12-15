using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Delta.WPF
{
    public static partial class VisualExtention
    {
        public static T OnClick<T>(this T node, RoutedEventHandler handlerFactory) where T : IButton
        {
            node.AddEvent ("Click", handlerFactory);
            return node;
        }
        public static T OnHover<T>(this T node, MouseEventHandler handlerFactory) where T : IVisual
        {
            node.AddEvent ("MouseEnter", handlerFactory);
            node.AddEvent ("MouseLeave", handlerFactory);
            return node;
        }

        public static IElement OnTextChanged<T>(this T node, TextChangedEventHandler handlerFactory) where T : IInput
        {
            if(node.Type != "TextBox")
            {
                return node;
            }
            return node.AddEvent ("TextChanged", handlerFactory);
        }
    }
}
