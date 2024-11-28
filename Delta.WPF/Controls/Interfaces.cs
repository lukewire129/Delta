using System.Collections.Generic;

namespace Delta.WPF
{
    public interface IVisual<T>
    {
        Dictionary<string, object> Properties { get; }

        T Width(double value);
        T Height(double value);
    }

    public interface IGrid<T> : IVisual<T>
    {

    }

    public interface IContent<T> : IVisual<T>
    {
        T Content(object o);
    }
}
