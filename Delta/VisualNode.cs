using System;

namespace Delta
{
    public abstract class VisualNode<T>
    {
        public string Id { get; } = Guid.NewGuid ().ToString ();

        public abstract T CreateElement();
    }
}
