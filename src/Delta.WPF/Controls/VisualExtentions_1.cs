using System.Drawing;
using System.Windows;

namespace Delta.WPF
{
    public static partial class VisualExtention
    {
        public static IElement Row(this IElement node, int value)
        {
            return node.SetProperty ("Grid.Row", value);
        }
        public static IElement Column(this IElement node, int value)
        {
            return node.SetProperty ("Grid.Column", value);
        }
        public static IElement RowSpan(this IElement node, int value)
        {
            return node.SetProperty ("Grid.RowSpan", value);
        }
        public static IElement ColumnSpan(this IElement node, int value)
        {
            return node.SetProperty ("Grid.ColumnSpan", value);
        }
        public static IElement Size(this IElement node, double width = 0.0, double height = 0.0)
        {
            return node.Width (width)
                       .Height(height);
        }

        public static IElement Width(this IElement node, double value)
        {
            return node.SetProperty (nameof (Width), value);
        }

        public static IElement Height(this IElement node, double value)
        {
            return node.SetProperty (nameof (Height), value);
        }

        public static IElement Margin(this IElement node, double left = 0.0, double top = 0.0, double right = 0.0, double bottom = 0.0)
        {
            return node.SetProperty (nameof (Margin), new Thickness(left, top, right, bottom));
        }

        public static IElement Background(this IElement node, System.Windows.Media.SolidColorBrush brushes)
        {
            return node.SetProperty (nameof (Background), brushes);
        }
        public static IElement Background(this IElement node, Color color)
        {
            return node.SetProperty (nameof (Background), new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (color)));
        }
        public static IElement Background(this IElement node, string colorCode)
        {
            if (colorCode[0] != '#')
                throw new System.Exception ("ColorCode Error");

            return node.SetProperty (nameof (Background), new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (ColorTranslator.FromHtml (colorCode))));
        }

        public static IElement Start(this IElement node)
        {
            return node.SetProperty ("HorizontalAlignment", HorizontalAlignment.Left);
        }
        public static IElement HCenter(this IElement node)
        {
            return node.SetProperty ("HorizontalAlignment", HorizontalAlignment.Center);
        }
        public static IElement End(this IElement node)
        {
            return node.SetProperty ("HorizontalAlignment", HorizontalAlignment.Right);
        }
        public static IElement Top(this IElement node)
        {
            return node.SetProperty ("VerticalAlignment", VerticalAlignment.Top);
        }
        public static IElement VCenter(this IElement node)
        {
            return node.SetProperty ("VerticalAlignment", VerticalAlignment.Center);
        }
        public static IElement Bottom(this IElement node)
        {
            return node.SetProperty ("VerticalAlignment", VerticalAlignment.Bottom);
        }
        public static IElement Center(this IElement node)
        {
            return node.HCenter ().VCenter ();
        }
    }
}
