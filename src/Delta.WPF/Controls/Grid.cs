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

        private List<RowDefinition> GetRowsDefinitions()
        {
            // RowDefinitions 속성에 추가
            if (!this.Properties.TryGetValue ("RowDefinitions", out var value) || value is not List<RowDefinition> rows)
            {
                rows = new List<RowDefinition> ();
                this.Properties["RowDefinitions"] = rows;
            }

            return rows;
        }

        private List<ColumnDefinition> GetColumnsDefinitions()
        {
            // ColumnDefinitions 속성에 추가
            if (!this.Properties.TryGetValue ("ColumnDefinitions", out var value) || value is not List<ColumnDefinition> columns)
            {
                columns = new List<ColumnDefinition> ();
                this.Properties["ColumnDefinitions"] = columns;
            }

            return columns;
        }

        public Grid RowDefinition(params GridLength[] heights)
        {
            var rows = this.GetRowsDefinitions ();
            foreach (var height in heights)
            {
                rows.Add (new RowDefinition { Height = height });
            }
            return this;
        }

        public Grid ColumnDefinition(params GridLength[] widths)
        {
            var columns = this.GetColumnsDefinitions ();
            foreach (var width in widths)
            {
                columns.Add (new ColumnDefinition { Width = width });
            }
            return this;
        }
    }
}
