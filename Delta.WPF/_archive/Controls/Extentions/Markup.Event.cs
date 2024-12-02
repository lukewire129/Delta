using System;
using System.Windows;

namespace Delta.WPF
{
    public static partial class Markup
    {
        public static VisualNode OnClick(this VisualNode node, RoutedEventHandler handlerFactory)
        {
            return node.AddEvent ("Click", handlerFactory);
        }
    }
}
