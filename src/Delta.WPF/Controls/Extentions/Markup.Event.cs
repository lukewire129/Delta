using System.Windows;

namespace Delta.WPF
{
    public static partial class Markup
    {
        public static IElement OnClick(this IElement node, RoutedEventHandler handlerFactory)
        {
            return node.AddEvent ("Click", handlerFactory);
        }
    }
}
