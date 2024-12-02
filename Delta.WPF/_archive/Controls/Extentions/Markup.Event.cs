using System.Windows;

namespace Delta.WPF
{
    public static partial class Markup
    {
        public static VisualNode OnClick(this VisualNode node, RoutedEventHandler handler)
        {
            return node.AddEvent ("Click", handler);
        }
    }
}
