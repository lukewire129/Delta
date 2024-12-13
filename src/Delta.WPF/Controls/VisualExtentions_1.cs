using System.Drawing;
using System.Windows;

namespace Delta.WPF
{
    public static partial class VisualExtention
    {
        public static T Row<T>(this T node, int value) where T  : IElement
        {
            node.SetProperty ("Grid.Row", value);
            return node;
        }
        public static T Column<T>(this T node, int value) where T : IElement
        {
            node.SetProperty ("Grid.Column", value);
            return node;
        }
        public static T RowSpan<T>(this T node, int value) where T : IElement
        {
            node.SetProperty ("Grid.RowSpan", value);
            return node;
        }
        public static T ColumnSpan<T>(this T node, int value) where T : IElement
        {
            node.SetProperty ("Grid.ColumnSpan", value);
            return node;
        }
        public static T Size<T>(this T node, double width = 0.0, double height = 0.0) where T : IElement
        {
            node.Width (width)
                .Height(height);
            return node;
        }

        public static T Width<T>(this T node, double value) where T : IElement
        {
            node.SetProperty (nameof (Width), value);
            return node;
        }

        public static T Height<T>(this T node, double value) where T : IElement
        {
            node.SetProperty (nameof (Height), value);
            return node;
        }
        public static T Margin<T>(this T node, double value = 0.0) where T : IElement
        {
            node.SetProperty (nameof (Margin), new Thickness (value, value, value, value));
            return node;
        }

        public static T Margin<T>(this T node, double left = 0.0, double top = 0.0, double right = 0.0, double bottom = 0.0) where T : IElement
        {
            node.SetProperty (nameof (Margin), new Thickness(left, top, right, bottom));
            return node;
        }

        public static T Background<T>(this T node, System.Windows.Media.LinearGradientBrush brushes) where T : IElement
        {
            node.SetProperty (nameof (Background), brushes);
            return node;
        }

        public static T Background<T>(this T node, System.Windows.Media.SolidColorBrush brushes) where T : IElement
        {
            node.SetProperty (nameof (Background), brushes);
            return node;
        }
        public static T Background<T>(this T node, Color color) where T : IElement
        {
            node.SetProperty (nameof (Background), new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (color)));
            return node;
        }
        public static T Background<T>(this T node, string colorCode) where T : IElement
        {
            if (colorCode[0] != '#')
                throw new System.Exception ("ColorCode Error");

            node.SetProperty (nameof (Background), new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (ColorTranslator.FromHtml (colorCode))));

            return node;
        }

        public static T Start<T>(this T node) where T : IElement
        {
            node.SetProperty ("HorizontalAlignment", HorizontalAlignment.Left);
            return node;
        }
        public static T HCenter<T>(this T node) where T : IElement
        {
            node.SetProperty ("HorizontalAlignment", HorizontalAlignment.Center);
            return node;
        }
        public static T End<T>(this T node) where T : IElement
        {
            node.SetProperty ("HorizontalAlignment", HorizontalAlignment.Right);
            return node;
        }
        public static T Top<T>(this T node) where T : IElement
        {
            node.SetProperty ("VerticalAlignment", VerticalAlignment.Top);
            return node;
        }
        public static T VCenter<T>(this T node) where T : IElement
        {
            node.SetProperty ("VerticalAlignment", VerticalAlignment.Center);
            return node;
        }
        public static T Bottom<T>(this T node) where T : IElement
        {
            node.SetProperty ("VerticalAlignment", VerticalAlignment.Bottom);
            return node;
        }
        public static T Center<T>(this T node) where T : IElement
        {
            node.HCenter ().VCenter ();
            return node;
        }
    }
}
