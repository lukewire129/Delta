using Delta.WPF.Controls.Base;
using SkiaSharp;

namespace Delta.WPF.Controls
{
    public class SkiaVStack : StackPanelBase
    {
        public override void Render(SKCanvas canvas, SKRect bounds)
        {
            RenderChildren (canvas, bounds, isVertical: true);
        }
    }
}
