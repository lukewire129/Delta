﻿using System.Drawing;
using System.Windows;

namespace Delta.WPF
{
    public static partial class VisualExtention
    {
        public static T FontWeight<T>(this T node, FontWeight weight) where T : IElement
        {
            node.SetProperty (nameof (FontWeight), weight);
            return node;
        }

        public static T FontSize<T>(this T node, double size) where T : IElement
        {
            node.SetProperty (nameof (FontSize), size);
            return node;
        }
        public static T FontFamily<T>(this T node, object content) where T : IElement
        {
            node.SetProperty (nameof (FontFamily), content);
            return node;
        }
        public static T FontColor<T>(this T node, System.Windows.Media.LinearGradientBrush brushes) where T : IElement
        {
            node.SetProperty ("Foreground", brushes);
            return node;
        }

        public static T FontColor<T>(this T node, System.Windows.Media.SolidColorBrush brushes) where T : IElement
        {
            node.SetProperty ("Foreground", brushes);
            return node;
        }

        public static T FontColor<T>(this T node, Color color) where T : IElement
        {
            node.SetProperty ("Foreground", new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (color)));
            return node;
        }

        public static T FontColor<T>(this T node, string colorCode) where T : IElement
        {
            if (colorCode[0] != '#')
                throw new System.Exception ("ColorCode Error");

            node.SetProperty ("Foreground", new System.Windows.Media.SolidColorBrush (ColorHelper.ToSWMColor (ColorTranslator.FromHtml (colorCode))));

            return node;
        }
    }
}
