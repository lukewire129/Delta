using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Delta.WPF.Controls
{
    internal class SkiaInput : VisualNode
    {
        private string _text = "";

        public SkiaInput Text(string text)
        {
            _text = text;
            return this;
        }

        public override void Render(SKCanvas canvas, SKRect bounds)
        {
            // Draw input box
            using var paint = new SKPaint { Style = SKPaintStyle.Stroke, Color = SKColors.Gray, StrokeWidth = 2 };
            canvas.DrawRect (bounds, paint);

            // Draw text
            paint.Style = SKPaintStyle.Fill;
            paint.Color = SKColors.Black;
            paint.TextSize = 20;
            var textX = bounds.Left + 10;
            var textY = bounds.Top + 30;
            canvas.DrawText (_text, textX, textY, paint);
        }
    }
}
