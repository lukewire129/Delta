using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF
{
    public static partial class Markup
    {
        private static List<RowDefinition> GetRowsDefinitions<T>(this T node) where T : IGrid<T>
        {
            // RowDefinitions 속성에 추가
            if (!node.Properties.TryGetValue ("RowDefinitions", out var value) || value is not List<RowDefinition> rows)
            {
                rows = new List<RowDefinition> ();
                node.Properties["RowDefinitions"] = rows;
            }

            return rows;
        }
        private static List<ColumnDefinition> GetColumnsDefinitions<T>(this T node) where T : IGrid<T>
        {
            // ColumnDefinitions 속성에 추가
            if (!node.Properties.TryGetValue ("ColumnDefinitions", out var value) || value is not List<ColumnDefinition> columns)
            {
                columns = new List<ColumnDefinition> ();
                node.Properties["ColumnDefinitions"] = columns;
            }

            return columns;
        }
        public static T Rows<T>(this T node, params double[] heights) where T : IGrid<T>
        {
            var rows = node.GetRowsDefinitions ();
            foreach (var height in heights)
            {
                rows.Add (new RowDefinition { Height = new GridLength (height, GridUnitType.Pixel) });
            }
            return node;
        }

        public static T Columns<T>(this T node, params double[] widths) where T : IGrid<T>
        {
            var columns = node.GetColumnsDefinitions ();
            foreach (var width in widths)
            {
                columns.Add (new ColumnDefinition { Width = new GridLength (width, GridUnitType.Pixel) });
            }
            return node;
        }

        public static T RowDefinition<T>(this T node, double height) where T : IGrid<T>
        {
            var rows = node.GetRowsDefinitions ();
            rows.Add (new RowDefinition { Height = new GridLength (height, GridUnitType.Pixel) });
            return node;
        }

        public static T ColumnDefinition<T>(this T node, double width) where T : IGrid<T>
        {
            var columns = node.GetColumnsDefinitions ();
            columns.Add (new ColumnDefinition { Width = new GridLength (width, GridUnitType.Pixel) });
            return node;
        }

        public static T RowDefinition<T>(this T node, GridLength gridLength) where T: IGrid<T>
        {
            var rows = node.GetRowsDefinitions ();
            rows.Add (new RowDefinition { Height = gridLength });
            return node;
        }

        public static T ColumnDefinition<T>(this T node, GridLength gridLength) where T : IGrid<T>
        {
            var columns = node.GetColumnsDefinitions ();
            columns.Add (new ColumnDefinition { Width = gridLength });
            return node;
        }

        // Auto GridLength
        public static GridLength Auto() => new GridLength (1, GridUnitType.Auto);

        // Star (*) GridLength
        public static GridLength Star(double value = 1) => new GridLength (value, GridUnitType.Star);
    }
}
