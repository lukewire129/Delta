using System.Linq;
using System.Windows;

namespace Delta.WPF
{
    public partial class Button : ContentControl, IVisual
    {
        public Button() : base ("Button") { }
        public Button (object o) : base ("Button") 
        {
            this.Content (o);
        }
        public Button(object o, RoutedEventHandler handlerFactory) : base ("Button")
        {
            this.Content (o);
            this.OnClick (handlerFactory);
        }
    }

    public partial class VStack : VisualNode
    {
        public VStack() : base ("StackPanel") {
            this.SetProperty ("Orientation", System.Windows.Controls.Orientation.Vertical);
        }
        public VStack(params IVisual[] node) : this()
        {
            this.Children = node.ToList ();
        }
    }

    public partial class HStack : VisualNode
    {
        public HStack() : base ("StackPanel") {
            this.SetProperty ("Orientation", System.Windows.Controls.Orientation.Horizontal);
        }
        public HStack(params IVisual[] node) : this ()
        {
            this.Children = node.ToList ();
        }
    }

    public partial class Text : ContentControl
    {
        public Text() : base ("Label") { }
        public Text(object o) : base ("Label")
        {
            this.Content (o);
        }
    }

    public partial class Input : VisualNode
    {
        public Input() : base ("TextBox") { }
    }
}
