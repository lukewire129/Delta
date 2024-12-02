using Delta.WPF.Builder;
using System;
using System.Diagnostics;
using System.Windows;

namespace Delta.WPF
{
    public abstract partial class HookComponent : System.Windows.Controls.ContentControl
    {
        private static readonly StateStore _stateStore = new ();
        private int _stateIndex = 0;
        public string ComponentId { get; } = Guid.NewGuid ().ToString ();
        protected VisualNode _currentVisualNode;

        public HookComponent()
        {
            _currentVisualNode = Render ();
            this.Content = MarkupBuilder.Build (_currentVisualNode);
        }

        public abstract VisualNode Render();

        protected (T state, Action<T> setState) UseState<T>(T initialValue)
        {
            var index = _stateIndex;
            Debug.WriteLine ($"UseState called. Index: {index}");

            var state = _stateStore.GetOrCreateState (ComponentId, index, initialValue);

            void SetState(T updater)
            {
                Debug.WriteLine ($"SetState called for index {index}. New value: {updater}");
                _stateStore.UpdateState (ComponentId, index, updater);

                Rebuild ();
            }

            _stateIndex++;
            return (state, SetState);
        }


        public void Rebuild()
        {
            Debug.WriteLine ("[Rebuild] Resetting _stateIndex to 0.");

            _stateIndex = 0;
            var newVisualNode = Render ();

            Debug.WriteLine ("[Rebuild] Render completed. New VisualNode created.");
            var diffOperations = DiffEngine.Diff (_currentVisualNode, newVisualNode);

            if (this.Content is FrameworkElement rootElement)
            {
                Debug.WriteLine ("[Rebuild] Applying diff operations to root element.");
                RenderingEngine.ApplyDiff (rootElement, diffOperations);
            }

            Debug.WriteLine ("[Rebuild] Updating _currentVisualNode.");
            _currentVisualNode = newVisualNode;

            UseEffect ();
        }
    }
}
