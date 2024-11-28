using System.Windows;

namespace Delta.WPF
{
    public static partial class Markup
    {
        public static VirtualNode OnClick(this VirtualNode node, RoutedEventHandler handler)
        {
            return node.AddEvent ("Click", handler);
        }
    }
}
