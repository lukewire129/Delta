using System;
using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF
{
    public abstract class HookComponent : ContentControl
    {
        private static readonly StateStore _stateStore = new ();
        private int _stateIndex = 0;
        public string ComponentId { get; } = Guid.NewGuid ().ToString ();

        protected HookComponent()
        {
            this.Rebuild ();
        }
        protected (T state, Action<T> setState) UseState<T>(T initialValue)
        {
            var index = _stateIndex;
            var state = _stateStore.GetOrCreateState (ComponentId, index, initialValue);
            _stateIndex++;

            void SetState(T newValue)
            {
                _stateStore.UpdateState (ComponentId, index, newValue);
                Rebuild ();
            }

            return (state, SetState);
        }

        public void Rebuild()
        {
            _stateIndex = 0;
            var rootNode = Render ();
            if (Content is UIElement existingContent)
            {
                rootNode.DiffAndUpdate (existingContent);
            }
            else
            {
                Content = rootNode.CreateElement ();
            }
        }

        public abstract VisualNode Render();
    }
}
