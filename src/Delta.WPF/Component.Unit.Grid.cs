namespace Delta.WPF
{
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
                        .ColumnDefinition (Columns().Lengths)
                        .RowDefinition (rowHeights.Lengths);
        }
        public static IGrid Grid(ColumnWidths columnWidths, params IElement[] nodes)
        {
            return new Grid (nodes)
                        .RowDefinition (Rows().Lengths)
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
}
