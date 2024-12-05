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
        IElement AddEvent(string eventName, Delegate handler);
        bool Equals(object obj);
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
}
