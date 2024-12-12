using System.Windows;

namespace Delta.WPF
{
    public static partial class VisualExtention
    {
        public static IElement TextStart<T>(this T node) where T : IInput
        {
            return node.SetProperty ("HorizontalContentAlignment", HorizontalAlignment.Left);
        }
        public static IElement TextHCenter<T>(this T node) where T : IInput
        {
            return node.SetProperty ("HorizontalContentAlignment", HorizontalAlignment.Center);
        }
        public static IElement TextEnd<T>(this T node) where T : IInput
        {
            return node.SetProperty ("HorizontalContentAlignment", HorizontalAlignment.Right);
        }
        public static IElement TextTop<T>(this T node) where T : IInput
        {
            return node.SetProperty ("VerticalContentAlignment", VerticalAlignment.Top);
        }
        public static IElement TextVCenter<T>(this T node) where T : IInput
        {
            return node.SetProperty ("VerticalContentAlignment", VerticalAlignment.Center);
        }
        public static IElement TextBottom<T>(this T node) where T : IInput
        {
            return node.SetProperty ("VerticalContentAlignment", VerticalAlignment.Bottom);
        }
        public static IElement TextCenter<T>(this T node) where T : IInput
        {
            return node.HCenter ().VCenter ();
        }
    }
}
