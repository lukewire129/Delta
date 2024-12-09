using System.Windows;

namespace Delta.WPF
{
    public static partial class Markup
    {
        public static T Content<T>(this T node, object content) where T : IContent
        {
            return node.Content (content);
        }
        public static IElement Text(this IElement node, string text)
        {
            return node.SetProperty ("Text", text);
        }
    }
}
