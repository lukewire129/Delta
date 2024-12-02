using Delta.WPF.Builder;
using System.Windows;

namespace Delta.WPF
{
    public abstract partial class Component : System.Windows.Controls.ContentControl
    {
        protected VisualNode _currentVisualNode;

        public Component()
        {
            _currentVisualNode = Build ();
            this.Content = MarkupBuilder.Build (_currentVisualNode);
        }

        public abstract VisualNode Build();

        private void StateChanage()
        {
            var newVisualNode = Build ();
            var diffOperations = DiffEngine.Diff (_currentVisualNode, newVisualNode);
            if (this.Content is FrameworkElement rootElement)
            {
                RenderingEngine.ApplyDiff (rootElement, diffOperations);
            }

            // 현재 VisualNode 상태 업데이트
            _currentVisualNode = newVisualNode;
        }
    }
}
