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

            void SetState(T updater)
            {
                _stateStore.UpdateState (ComponentId, index, updater);

                Rebuild ();
            }

            _stateIndex++;
            return (state, SetState);
        }

        public void Rebuild()
        {
            var rootNode = Render (); // 새 트리를 생성
            _stateIndex = 0; // 렌더링 이후 상태 인덱스를 초기화

            if (Content is UIElement existingContent)
            {
                rootNode.DiffAndUpdate (existingContent); // 기존 트리와 새로운 트리를 비교
            }
            else
            {
                Content = rootNode.CreateElement (); // 초기 렌더링
            }
        }

        public abstract VisualNode Render();
    }
}
