using System.Windows;

namespace Delta.WPF
{
    public class VStack : Panel
    {
        public override UIElement CreateElement()
        {
            var stackPanel = new System.Windows.Controls.StackPanel { Orientation = System.Windows.Controls.Orientation.Vertical };
            foreach (var child in Children)
            {
                stackPanel.Children.Add (child.CreateElement ());
            }
            return stackPanel;
        }
    }
}
