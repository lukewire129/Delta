using System.Drawing;
using System.Windows;

namespace Delta.WPF
{
    public interface IBorder : IVisual
    {

    }

    public abstract partial class Component
    {
        public static IBorder Border(object o)
        {
            return new Border (o);
        }

        public static IBorder Border(IElement element)
        {
            return new Border (element);
        }
    }

    public partial class Border : ContentControl, IBorder
    {
        public Border(IElement element) : base ("Border")
        {
            this.Content (element);
        }
        public Border(object o) : base ("Border")
        {
            this.Content (o);
        }
    }

    public static partial class BorderVisualExtention
    {
        public static T CornerRadius<T>(this T node, double value = 0.0) where T : IBorder
        {
            node.SetProperty ("CornerRadius", new CornerRadius (value, value, value, value));
            return node;
        }

        public static T CornerRadius<T>(this T node, double left = 0.0, double top = 0.0, double right = 0.0, double bottom = 0.0) where T : IElement
        {
            node.SetProperty ("CornerRadius", new CornerRadius (left, top, right, bottom));
            return node;
        }
        public static T Padding<T>(this T node, double value = 0.0) where T : IBorder
        {
            node.SetProperty ("Padding", new Thickness (value, value, value, value));
            return node;
        }

        public static T Padding<T>(this T node, double left = 0.0, double top = 0.0, double right = 0.0, double bottom = 0.0) where T : IElement
        {
            node.SetProperty ("Padding", new Thickness (left, top, right, bottom));
            return node;
        }

        public static T Thickness<T>(this T node, double value) where T : IBorder
        {
            node.SetProperty ("BorderThickness", new Thickness (value, value, value, value));
            return node;
        }

        public static T Thickness<T>(this T node, double left = 0.0, double top = 0.0, double right = 0.0, double bottom = 0.0) where T : IBorder
        {
            node.SetProperty ("BorderThickness", new Thickness (left, top, right, bottom));
            return node;
        }

        public static T Brush<T>(this T node, System.Windows.Media.SolidColorBrush brushes) where T : IBorder
        {
            node.SetProperty ("BorderBrush", brushes);
            if (node.TryGetValue ("BorderThickness", out var row))
            {
                return node;
            }
            node.Thickness (1);
            return node;
        }
        public static T Brush<T>(this T node, Color color) where T : IBorder
        {
            node.SetProperty ("BorderBrush", new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (color)));
            if (node.TryGetValue ("BorderThickness", out var row))
            {
                return node;
            }
            node.Thickness (1);
            return node;
        }

        public static T Brush<T>(this T node, string colorCode) where T : IBorder
        {
            if (colorCode[0] != '#')
                throw new System.Exception ("ColorCode Error");

            node.SetProperty ("BorderBrush", new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (ColorTranslator.FromHtml (colorCode))));
            if (node.TryGetValue ("BorderThickness", out var row))
            {
                return node;
            }
            node.Thickness (1);
            return node;
        }
    }
}
