using System;
using System.Diagnostics;
using System.Windows;

namespace Delta.WPF
{
    public abstract partial class Component : VisualElement
    {
        private static readonly StateStore _stateStore = new ();
        private int _stateIndex = 0;
        public Component() : base("Grid")
        {
            ApplicationRoot.Instance.StateIndexInitialize += () =>
            {
                _stateIndex = 0;
            };
            this.Id = Guid.NewGuid ().ToString ();
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

        public IElement VirtualRender()
        {
            var root = this.Render ();
            this.Children.Add (root);
            //foreach (var element in root.Children)
            //{
            //    this.Children.Add (element);
            //}
            return this;
        }
    }
}
