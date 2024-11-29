using SkiaSharp;

namespace Delta.WPF.Controls
{
    public class SkiaHost
    {
        private readonly VisualTree _visualTree;

        public SkiaHost(VisualTree visualTree)
        {
            _visualTree = visualTree;
        }

        public void Render(SKCanvas canvas)
        {
            var root = _visualTree.Build ();
            root.Render (canvas, new SKRect (0, 0, 800, 600)); // 기본 크기 설정
        }
    }
}
