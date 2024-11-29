using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF.cc
{
    public class DeltaGrid : VisualNode
    {

        public DeltaGrid()
        {
        }
        public override UIElement CreateElement()
        {
            var grid = new Grid
            {
            };
            return grid;
        }
    }
}
