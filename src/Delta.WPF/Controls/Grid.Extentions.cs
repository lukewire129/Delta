using System.Windows.Controls;
namespace Delta.WPF
{
    public static partial class Markup
    {
        public static T RowDefinition<T>(this T node, params GridLength[] heights) where T : IGrid
        {
            var rows = node.GetRowsDefinitions ();
            foreach (var height in heights)
            {
                rows.Add (new RowDefinition { Height = height });
            }
            return node;
        }

        public static T ColumnDefinition<T>(this T node, params GridLength[] widths) where T : IGrid
        {
            var columns = node.GetColumnsDefinitions ();
            foreach (var width in widths)
            {
                columns.Add (new ColumnDefinition { Width = width });
            }
            return node;
        }
    }
}
