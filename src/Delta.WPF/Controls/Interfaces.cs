using System.Collections.Generic;

namespace Delta.WPF
{

    public interface IVisual : IElement
    {
    }

    public interface IContent : IVisual
    {

    }

    public interface IFont : IVisual
    {
    }
    public interface IInput : IVisual
    {
    }

    public interface IScroll : IVisual
    {
    }
}
