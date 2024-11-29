using SkiaSharp;

namespace Delta.WPF.Controls.Base
{
    public abstract class StackPanelBase : PanelBase
    {
        public float Spacing { get; set; } = 0;
        protected readonly List<VisualNode> _children = new ();

        public StackPanelBase AddChild(VisualNode node)
        {
            _children.Add (node);
            return this;
        }

        public StackPanelBase SetSpacing(float spacing)
        {
            Spacing = spacing;
            return this;
        }

        protected void RenderChildren(SKCanvas canvas, SKRect bounds, bool isVertical)
        {
            var paddedBounds = ApplyPadding (bounds);
            float offset = isVertical ? paddedBounds.Top : paddedBounds.Left;

            foreach (var child in _children)
            {
                var childBounds = isVertical
                    ? new SKRect (paddedBounds.Left, offset, paddedBounds.Right, offset + child.Height)
                    : new SKRect (offset, paddedBounds.Top, offset + child.Width, paddedBounds.Bottom);

                child.Render (canvas, childBounds);
                offset += (isVertical ? child.Height : child.Width) + Spacing;
            }
        }
    }
}
