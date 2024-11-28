using System.Linq;

namespace Delta.WPF
{
    public class Grid : Visual, IGrid<VisualNode>
    {
        public Grid() : base ("Grid") { }

        public Grid(params VisualNode[] node) : base ("Grid")
        {
            this.Children = node.ToList ();
        }
    }
    public partial class Button : ContentControl, IVisual<VisualNode>
    {
        public Button() : base ("Button") { }
        public Button (object o) : base ("Button") 
        {
            this.Content (o);
        }
    }

    public partial class VStack : VisualNode
    {
        public VStack() : base ("StackPanel") {
            this.SetProperty ("Orientation", System.Windows.Controls.Orientation.Vertical);
        }
    }

    public partial class HStack : VisualNode
    {
        public HStack() : base ("StackPanel") {
            this.SetProperty ("Orientation", System.Windows.Controls.Orientation.Horizontal);
        }
    }

    public partial class Text : ContentControl
    {
        public Text() : base ("Label") { }
        public Text(object o) : base ("Button")
        {
            this.Content (o);
        }
    }

    public partial class Input : VisualNode
    {
        public Input() : base ("TextBox") { }
    }
}
