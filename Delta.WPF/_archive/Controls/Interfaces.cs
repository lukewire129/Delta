using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Delta.WPF
{
    public interface IElement
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }

    public interface IVisual : IElement
    {
        Dictionary<string, object> Properties { get; set; }        
        public Dictionary<string, Delegate> Events { get; set; }
        public List<IVisual> Children { get; set; }
        VisualNode SetProperty(string name, object value);
    }

    public interface IGrid : IVisual
    {
        List<RowDefinition> GetRowsDefinitions();
        List<ColumnDefinition> GetColumnsDefinitions();
    }

    public interface IContent : IVisual
    {
    }
}
