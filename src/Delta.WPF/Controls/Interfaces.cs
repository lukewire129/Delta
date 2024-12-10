using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Delta.WPF
{
    public interface IElement
    {
        string Id { get; set; }
        string Type { get; set; }
        bool TryGetValue(string propertyName, [MaybeNullWhen (false)] out object value);
        public List<IElement> Children { get; set; }
        Dictionary<string, object> Properties { get; set; }
        IElement SetProperty(string name, object value);
        public Dictionary<string, Delegate> Events { get; set; }
        bool Equals(object obj);
        public void LoadNodeNumber(int parentId, int myId);
        IElement AddEvent(string eventName, Delegate handler);
    }

    public interface IVisual : IElement
    {
    }

    public interface IGrid : IVisual
    {
        List<System.Windows.Controls.RowDefinition> GetRowsDefinitions();
        List<System.Windows.Controls.ColumnDefinition> GetColumnsDefinitions();
    }

    public interface IContent : IVisual
    {

    }

    public interface IText : IElement
    {
    }
    public interface IInput : IElement
    {
    }
    public interface IRadio : IElement
    {

    }
    public interface ICheck : IElement
    {

    }

    public interface IScroll : IElement
    {
    }
}
