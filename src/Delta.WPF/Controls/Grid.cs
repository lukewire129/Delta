using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF
{

    public interface IGrid : IVisual
    {
    }

    public abstract partial class Component
    {
        public static IGrid Grid()
        {
            return new Grid ();
        }

        public static IGrid Grid(params IElement[] nodes)
        {
            return new Grid (nodes);
        }
        public static IGrid Grid(RowHeights rowHeights, params IElement[] nodes)
        {
            return new Grid (nodes)
                        .ColumnDefinition (Columns ().Lengths)
                        .RowDefinition (rowHeights.Lengths);
        }
        public static IGrid Grid(ColumnWidths columnWidths, params IElement[] nodes)
        {
            return new Grid (nodes)
                        .RowDefinition (Rows ().Lengths)
                        .ColumnDefinition (columnWidths.Lengths);
        }
        public static IGrid Grid(RowHeights rowHeights, ColumnWidths columnWidths, params IElement[] nodes)
        {
            return new Grid (nodes)
                        .RowDefinition (rowHeights.Lengths)
                        .ColumnDefinition (columnWidths.Lengths);
        }
        public static RowHeights Rows(params GridLength[] heights) => new RowHeights { Lengths = heights };
        public static ColumnWidths Columns(params GridLength[] widths) => new ColumnWidths { Lengths = widths };

        public struct RowHeights { internal GridLength[] Lengths; }

        public struct ColumnWidths { internal GridLength[] Lengths; }

        public static System.Windows.GridLength Auto => System.Windows.GridLength.Auto;

        public static System.Windows.GridLength Star = new System.Windows.GridLength (1, System.Windows.GridUnitType.Star);

        public static System.Windows.GridLength Stars(double value) => new System.Windows.GridLength (value, System.Windows.GridUnitType.Star);
    }

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
