using System.Collections.Generic;

namespace Delta.WPF
{

    public interface IVisual : IElement
    {
    }

    public interface IGrid : IVisual
    {
    }

    public interface IContent : IVisual
    {

    }

    public interface IText : IVisual
    {
    }
    public interface IInput : IVisual
    {
    }
    public interface IRadio : IVisual
    {
    }
    public interface ICheck : IVisual
    {

    }

    public interface IScroll : IVisual
    {
    }
    public interface IImage : IVisual
    {
    }
}
