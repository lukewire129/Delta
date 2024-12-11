using System.Windows.Controls;
namespace Delta.WPF
{
    public static partial class Markup
    {
        public static IElement RowDefinition(this IGrid node, params GridLength[] heights)
        {
            var rows = node.GetRowsDefinitions ();
            foreach (var height in heights)
            {
                rows.Add (new RowDefinition { Height = height });
            }
            return node;
        }

        public static IElement ColumnDefinition(this IGrid node, params GridLength[] widths)
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
