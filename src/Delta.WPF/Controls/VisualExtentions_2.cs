using System.Drawing;

namespace Delta.WPF
{
    public static partial class VisualExtention
    {
        public static IElement FontSize<T>(this T node, double size) where T : IText
        {
            return node.SetProperty (nameof (FontSize), size);
        }
        public static IElement FontFamily<T>(this T node, object content) where T : IText
        {
            return node.SetProperty (nameof (FontFamily), content);
        }
        public static IElement FontColor<T>(this T node, System.Windows.Media.SolidColorBrush brushes) where T : IText
        {
            return node.SetProperty ("Foreground", brushes);
        }

        public static IElement FontColor(this IElement node, Color color)
        {
            return node.SetProperty ("Foreground", new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (color)));
        }

        public static IElement FontColor(this IElement node, string colorCode)
        {
            if (colorCode[0] != '#')
                throw new System.Exception ("ColorCode Error");

            return node.SetProperty ("Foreground", new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (ColorTranslator.FromHtml (colorCode))));
        }
    }
}
