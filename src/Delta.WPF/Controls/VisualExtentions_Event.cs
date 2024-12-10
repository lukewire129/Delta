using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF
{
    public static partial class VisualExtention
    {
        public static IElement OnClick(this IElement node, RoutedEventHandler handlerFactory)
        {
            return node.AddEvent ("Click", handlerFactory);
        }
        public static IElement OnChanged<T>(this T node, TextChangedEventHandler handlerFactory) where T : IInput
        {
            return node.AddEvent ("TextChanged", handlerFactory);
        }
    }
}
