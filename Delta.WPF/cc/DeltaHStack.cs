using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF.cc
{
    public class DeltaHStack : VisualNode
    {
        public override UIElement CreateElement()
        {
            var stackPanel = new StackPanel { Orientation = Orientation.Vertical };
            foreach (var child in Children)
            {
                stackPanel.Children.Add (child.CreateElement ());
            }
            return stackPanel;
        }

        public DeltaHStack AddChild(VisualNode child)
        {
            Children.Add (child);
            return this;
        }
    }
}
