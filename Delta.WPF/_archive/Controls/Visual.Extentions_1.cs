using System.Windows;

namespace Delta.WPF
{
    public static partial class Markup
    {
        public static IVisual Row(this IVisual node, int value)
        {
            return node.SetProperty ("Grid.Row", value);
        }
        public static IVisual Column(this IVisual node, int value)
        {
            return node.SetProperty ("Grid.Column", value);
        }

        public static IVisual Size(this IVisual node, double width = 0.0, double height = 0.0)
        {
            return node.Width (width)
                       .Height(height);
        }

        public static IVisual Width(this IVisual node, double value)
        {
            return node.SetProperty ("Width", value);
        }

        public static IVisual Height(this IVisual node, double value)
        {
            return node.SetProperty ("Height", value);
        }

        public static IVisual Start(this IVisual node)
        {
            return node.SetProperty ("HorizontalAlignment", HorizontalAlignment.Left);
        }
        public static IVisual HCenter(this IVisual node)
        {
            return node.SetProperty ("HorizontalAlignment", HorizontalAlignment.Center);
        }
        public static IVisual End(this IVisual node)
        {
            return node.SetProperty ("HorizontalAlignment", HorizontalAlignment.Right);
        }
        public static IVisual Top(this IVisual node)
        {
            return node.SetProperty ("VerticalAlignment", VerticalAlignment.Top);
        }
        public static IVisual VCenter(this IVisual node)
        {
            return node.SetProperty ("VerticalAlignment", VerticalAlignment.Center);
        }
        public static IVisual Bottom(this IVisual node)
        {
            return node.SetProperty ("VerticalAlignment", VerticalAlignment.Bottom);
        }
        public static IVisual Center(this IVisual node)
        {
            return node.HCenter ().VCenter ();
        }
    }
}
