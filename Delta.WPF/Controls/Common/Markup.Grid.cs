using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF
{
    public static partial class Markup
    {
        public static VirtualNode RowDefinition(this VirtualNode node, double height)
        {
            // RowDefinitions 속성에 추가
            if (!node.Properties.TryGetValue ("RowDefinitions", out var value) || value is not List<RowDefinition> rows)
            {
                rows = new List<RowDefinition> ();
                node.Properties["RowDefinitions"] = rows;
            }
            rows.Add (new RowDefinition { Height = new GridLength (height, GridUnitType.Pixel) });
            return node;
        }

        public static VirtualNode ColumnDefinition(this VirtualNode node, double width)
        {
            // ColumnDefinitions 속성에 추가
            if (!node.Properties.TryGetValue ("ColumnDefinitions", out var value) || value is not List<ColumnDefinition> columns)
            {
                columns = new List<ColumnDefinition> ();
                node.Properties["ColumnDefinitions"] = columns;
            }
            columns.Add (new ColumnDefinition { Width = new GridLength (width, GridUnitType.Pixel) });
            return node;
        }

        public static VirtualNode RowDefinition(this VirtualNode node, GridLength gridLength)
        {
            if (!node.Properties.TryGetValue ("RowDefinitions", out var value) || value is not List<RowDefinition> rows)
            {
                rows = new List<RowDefinition> ();
                node.Properties["RowDefinitions"] = rows;
            }
            rows.Add (new RowDefinition { Height = gridLength });
            return node;
        }

        public static VirtualNode ColumnDefinition(this VirtualNode node, GridLength gridLength)
        {
            if (!node.Properties.TryGetValue ("ColumnDefinitions", out var value) || value is not List<ColumnDefinition> columns)
            {
                columns = new List<ColumnDefinition> ();
                node.Properties["ColumnDefinitions"] = columns;
            }
            columns.Add (new ColumnDefinition { Width = gridLength });
            return node;
        }

        // Auto GridLength
        public static GridLength Auto() => new GridLength (1, GridUnitType.Auto);

        // Star (*) GridLength
        public static GridLength Star(double value = 1) => new GridLength (value, GridUnitType.Star);
    }
}
