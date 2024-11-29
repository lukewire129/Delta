using Delta.WPF.Controls.Base;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delta.WPF.Controls
{
    internal class SkiaGrid : PanelBase
    {
        private readonly List<(VisualNode Node, int Row)> _children = new ();
        private float[] _rowHeights = Array.Empty<float> ();

        public SkiaGrid Rows(params float[] heights)
        {
            _rowHeights = heights;
            return this;
        }

        public SkiaGrid AddChild(VisualNode node, int row)
        {
            _children.Add ((node, row));
            return this;
        }

        public override void Render(SKCanvas canvas, SKRect bounds)
        {
            float yOffset = bounds.Top;

            for (int row = 0; row < _rowHeights.Length; row++)
            {
                var rowHeight = _rowHeights[row];
                var rowBounds = new SKRect (bounds.Left, yOffset, bounds.Right, yOffset + rowHeight);

                foreach (var (child, childRow) in _children)
                {
                    if (childRow == row)
                    {
                        child.Render (canvas, rowBounds);
                    }
                }

                yOffset += rowHeight;
            }
        }
    }
}
