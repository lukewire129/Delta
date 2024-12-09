using System.Windows;

namespace Delta.WPF
{
    public class Grid : Panel
    {

        public Grid()
        {
        }
        public override UIElement CreateElement()
        {
            var grid = new System.Windows.Controls.Grid ();
            foreach (var child in Children)
            {
                grid.Children.Add (child.CreateElement ());
            }
            return grid;
        }
    }
}
