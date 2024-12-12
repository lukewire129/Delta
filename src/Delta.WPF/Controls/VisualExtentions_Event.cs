using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF
{
    public static partial class VisualExtention
    {
        public static IElement OnClick<T>(this T node, RoutedEventHandler handlerFactory) where T : IVisual
        {
            return node.AddEvent ("Click", handlerFactory);
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
