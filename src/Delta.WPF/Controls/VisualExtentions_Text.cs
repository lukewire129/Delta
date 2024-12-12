using System.Windows;

namespace Delta.WPF
{
    public static partial class VisualExtention
    {
        public static T TextStart<T>(this T node) where T : IInput
        {
            node.SetProperty ("HorizontalContentAlignment", HorizontalAlignment.Left);
            return node;
        }
        public static T TextHCenter<T>(this T node) where T : IInput
        {
            node.SetProperty ("HorizontalContentAlignment", HorizontalAlignment.Center);
            return node;
        }
        public static T TextEnd<T>(this T node) where T : IInput
        {
            node.SetProperty ("HorizontalContentAlignment", HorizontalAlignment.Right);
            return node;
        }
        public static T TextTop<T>(this T node) where T : IInput
        {
            node.SetProperty ("VerticalContentAlignment", VerticalAlignment.Top);
            return node;
        }
        public static T TextVCenter<T>(this T node) where T : IInput
        {
            node.SetProperty ("VerticalContentAlignment", VerticalAlignment.Center);
            return node;
        }
        public static T TextBottom<T>(this T node) where T : IInput
        {
            node.SetProperty ("VerticalContentAlignment", VerticalAlignment.Bottom);
            return node;
        }
        public static T TextCenter<T>(this T node) where T : IInput
        {
            node.HCenter ().VCenter ();
            return node;
        }
    }
}
