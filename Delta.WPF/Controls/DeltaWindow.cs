using Delta.WPF.Builder;
using System.Windows;

namespace Delta.WPF
{
    public abstract class DeltaWindow : Window
    {
        private VisualNode _currentVisualNode;

        public abstract VisualNode Build();

        public DeltaWindow()
        {
            _currentVisualNode = Build ();
            this.Content = MarkupBuilder.Build(_currentVisualNode);
        }

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
