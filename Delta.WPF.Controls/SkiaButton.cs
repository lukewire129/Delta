using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delta.WPF.Controls
{
    public class SkiaButton : VisualNode
    {
        private string _content = "Button";
        private Action<object, EventArgs>? _onClick;

        public SkiaButton Content(string content)
        {
            _content = content;
            return this;
        }

        public SkiaButton OnClick(Action<object, EventArgs> onClick)
        {
            _onClick = onClick;
            return this;
        }

        public SkiaButton Width(float width)
        {
            SetProperty ("Width", width);
            return this;
        }

        public SkiaButton Height(float height)
        {
            SetProperty ("Height", height);
            return this;
        }

        public override void Render(SKCanvas canvas, SKRect bounds)
        {
            var rect = new SKRect (bounds.Left, bounds.Top, bounds.Left + (float)Properties["Width"], bounds.Top + (float)Properties["Height"]);

            // Draw button
            using var paint = new SKPaint { Style = SKPaintStyle.Fill, Color = SKColors.LightGray };
            canvas.DrawRect (rect, paint);

            // Draw text
            paint.Style = SKPaintStyle.Fill;
            paint.Color = SKColors.Black;
            paint.TextSize = 20;
            var textWidth = paint.MeasureText (_content);
            var textX = rect.MidX - (textWidth / 2);
            var textY = rect.MidY + (paint.TextSize / 2);
            canvas.DrawText (_content, textX, textY, paint);
        }
    }
}
