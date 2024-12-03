using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF
{
    public interface IVisual
    {
        Dictionary<string, object> Properties { get; set; }
        public string Id { get; }
        public string Type { get; set; }
        public Dictionary<string, Delegate> Events { get; set; }
        public List<IVisual> Children { get; set; }
        VisualNode SetProperty(string name, object value);
        //T Width(double value);
        //T Height(double value);

        //T Margin(Thickness value);
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
