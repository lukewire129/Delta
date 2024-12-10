using System.Collections.Generic;
using System.Windows.Controls;

namespace Delta.WPF
{
    public class Grid : Panel, IGrid
    {
        public Grid() : base ("Grid") { }

        public Grid(params IElement[] node) : base ("Grid", node)
        {
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
