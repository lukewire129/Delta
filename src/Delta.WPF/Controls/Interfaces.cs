using System.Collections.Generic;

namespace Delta.WPF
{

    public interface IVisual : IElement
    {
    }

    public interface IContent : IVisual
    {

    }
    public interface IButton : IVisual
    {
    }
    public interface IInput : IVisual
    {
    }

    public interface IScroll : IVisual
    {
    }
}
