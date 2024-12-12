using System.Drawing;
using System.Windows;

namespace Delta.WPF
{
    public interface IShape : IVisual
    {

    }

    public partial class Shape : Visual
    {
        public Shape(string type) : base (type) { }
    }
    public static partial class ShapeVisualExtention
    {
        public static T Thickness<T>(this T node, double value) where T : IShape
        {
            node.SetProperty ("StrokeThickness", value);
            return node;
        }

        public static T Brush<T>(this T node, System.Windows.Media.SolidColorBrush brushes) where T : IShape
        {
            node.SetProperty ("Stroke", brushes);
            if (node.TryGetValue ("StrokeThickness", out var row))
            {
                return node;
            }
            node.Thickness (1);
            return node;
        }
        public static T Brush<T>(this T node, Color color) where T : IShape
        {
            node.SetProperty ("Stroke", new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (color)));
            if (node.TryGetValue ("StrokeThickness", out var row))
            {
                return node;
            }
            node.Thickness (1);
            return node;
        }

        public static T Brush<T>(this T node, string colorCode) where T : IShape
        {
            if (colorCode[0] != '#')
                throw new System.Exception ("ColorCode Error");

            node.SetProperty ("Stroke", new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (ColorTranslator.FromHtml (colorCode))));
            if (node.TryGetValue ("StrokeThickness", out var row))
            {
                return node;
            }
            node.Thickness (1);
            return node;
        }
    }
}
