using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Delta.WPF
{
    public partial class Control : VisualNode
    {
        public static IGrid Grid()
        {
            return new Grid ();
        }

        public static IGrid Grid(params IVisual[] nodes)
        {
            return new Grid (nodes);
        }
    }

    public class Grid : Visual, IGrid
    {
        public Grid() : base ("Grid") { }

        public Grid(params IVisual[] node) : base ("Grid")
        {
            this.Children = node.ToList ();
        }

        public List<RowDefinition> GetRowsDefinitions()
        {
            // RowDefinitions 속성에 추가
            if (!this.Properties.TryGetValue ("RowDefinitions", out var value) || value is not List<RowDefinition> rows)
            {
                rows = new List<RowDefinition> ();
                this.Properties["RowDefinitions"] = rows;
            }

            return rows;
        }
        public List<ColumnDefinition> GetColumnsDefinitions()
        {
            // ColumnDefinitions 속성에 추가
            if (!this.Properties.TryGetValue ("ColumnDefinitions", out var value) || value is not List<ColumnDefinition> columns)
            {
                columns = new List<ColumnDefinition> ();
                this.Properties["ColumnDefinitions"] = columns;
            }

            return columns;
        }
    }
}
