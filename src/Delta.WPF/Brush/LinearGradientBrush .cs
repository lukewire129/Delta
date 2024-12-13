using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Delta.WPF
{
    public abstract partial class Component
    {
        public static LinearGradientBrush LinearGradient(string startPoint, string endPoint)
        {
            // 문자열 값을 Point로 변환
            Point parsedStartPoint = ParsePoint (startPoint);
            Point parsedEndPoint = ParsePoint (endPoint);
            var temp = new LinearGradientBrush ();
            temp.StartPoint = parsedStartPoint;
            temp.EndPoint = parsedEndPoint;
            return temp;
        }

        private static Point ParsePoint(string pointString)
        {
            if (string.IsNullOrWhiteSpace (pointString))
            {
                throw new ArgumentException ("Point string cannot be null or empty.", nameof (pointString));
            }

            var values = pointString.Split (',');
            if (values.Length != 2 ||
                !double.TryParse (values[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var x) ||
                !double.TryParse (values[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var y))
            {
                throw new FormatException ($"Invalid point format: '{pointString}'. Expected format is 'x,y'.");
            }

            return new Point (x, y);
        }
    }
    public static partial class LinearGradientBrushExtention
    {
        public static LinearGradientBrush AddGradientStop(this LinearGradientBrush brush, string colorCode, double offset)
        {
            brush.GradientStops.Add (new GradientStop (ColorHelper.ToSWMColor (System.Drawing.ColorTranslator.FromHtml (colorCode)), offset));
            return brush;
        }
        public static LinearGradientBrush AddGradientStop(this LinearGradientBrush brush, Color color, double offset)
        {
            brush.GradientStops.Add (new GradientStop (color, offset));
            return brush;
        }
    }
}
