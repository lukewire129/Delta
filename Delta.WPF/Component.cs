using System;
using System.Diagnostics;

namespace Delta.WPF
{
    public abstract partial class Component : VisualElement, IDisposable
    {
        private static readonly StateStore _stateStore = new ();
        private int _stateIndex = 0;
        public Component() : base("Grid")
        {
            ApplicationRoot.Instance.StateIndexInitialize += () =>
            {
                _stateIndex = 0;
            };
        }

        public abstract IElement Render();

        protected (T state, Action<T> setState) UseState<T>(T initialValue)
        {
            var index = _stateIndex;
            Debug.WriteLine ($"UseState called. Index: {index}");

            var state = _stateStore.GetOrCreateState (Id, index, initialValue);

            void SetState(T updater)
            {
                Debug.WriteLine ($"SetState called for index {index}. New value: {updater}");
                _stateStore.UpdateState (Id, index, updater);


                ApplicationRoot.Instance.Rebuild (); // 루트 갱신 호출

                //UseEffect ();
            }

            _stateIndex++;
            return (state, SetState);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Debug.WriteLine ("Component disposing...");
                // 등록된 모든 클린업 호출
                foreach (var cleanup in _cleanupEffects)
                {
                    cleanup?.Invoke ();
                }
                _cleanupEffects.Clear ();
            }
        }

        public void Dispose()
        {
            Dispose (true);
            GC.SuppressFinalize (this);
        }
    }
}
