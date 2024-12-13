using System.Drawing;
using System.Windows.Media.Effects;

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
        public static T Brush<T>(this T node, System.Windows.Media.LinearGradientBrush brushes) where T : IShape
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
        public static T Fill<T>(this T node, System.Windows.Media.LinearGradientBrush brushes) where T : IShape
        {
            node.SetProperty ("Fill", brushes);
            return node;
        }
        public static T Fill<T>(this T node, System.Windows.Media.SolidColorBrush brushes) where T : IShape
        {
            node.SetProperty ("Fill", brushes);
            return node;
        }

        public static T Fill<T>(this T node, Color color) where T : IShape
        {
            node.SetProperty ("Fill", new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (color)));
            return node;
        }

        public static T Fill<T>(this T node, string colorCode) where T : IShape
        {
            if (colorCode[0] != '#')
                throw new System.Exception ("ColorCode Error");

            node.SetProperty ("Fill", new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (ColorTranslator.FromHtml (colorCode))));
            return node;
        }

        public static T DropShadowEffect<T>(this T node, System.Windows.Media.Color Color= default, double BlurRadius= 5.0, double Depth= 5.0, double Opacity=1.0, double Direction = 315.0, RenderingBias RenderingBias = RenderingBias.Performance) where T : IShape
        {
            if (Color == default)
            {
                Color = System.Windows.Media.Colors.Black;
            }

            var effect = new System.Windows.Media.Effects.DropShadowEffect
            {
                Color = Color,
                BlurRadius = BlurRadius,
                ShadowDepth = Depth,
                Opacity=Opacity,
                Direction= Direction,
                RenderingBias= RenderingBias
            };

            node.SetProperty ("Effect", effect);
            return node;
        }
    }
}
