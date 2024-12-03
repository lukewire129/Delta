using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF
{
    public static partial class Markup
    {
        public static T Rows<T>(this T node, params double[] heights) where T : IGrid
        {
            var rows = node.GetRowsDefinitions ();
            foreach (var height in heights)
            {
                rows.Add (new RowDefinition { Height = new GridLength (height, GridUnitType.Pixel) });
            }
            return node;
        }

        public static T Columns<T>(this T node, params double[] widths) where T : IGrid
        {
            var columns = node.GetColumnsDefinitions ();
            foreach (var width in widths)
            {
                columns.Add (new ColumnDefinition { Width = new GridLength (width, GridUnitType.Pixel) });
            }
            return node;
        }

        public static T RowDefinition<T>(this T node, double height) where T : IGrid
        {
            var rows = node.GetRowsDefinitions ();
            rows.Add (new RowDefinition { Height = new GridLength (height, GridUnitType.Pixel) });
            return node;
        }

        public static T ColumnDefinition<T>(this T node, double width) where T : IGrid
        {
            var columns = node.GetColumnsDefinitions ();
            columns.Add (new ColumnDefinition { Width = new GridLength (width, GridUnitType.Pixel) });
            return node;
        }

        public static T RowDefinition<T>(this T node, GridLength gridLength) where T: IGrid
        {
            var rows = node.GetRowsDefinitions ();
            rows.Add (new RowDefinition { Height = gridLength });
            return node;
        }

        public static T ColumnDefinition<T>(this T node, GridLength gridLength) where T : IGrid
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
