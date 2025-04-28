using System.Windows;

namespace Delta.WPF
{
  
    public partial class Scroll : ContentControl, IScroll
    {
        public Scroll(IElement element) : base ("ScrollViewer")
        {
            this.Content (element);
        }
        public Scroll(object o) : base ("ScrollViewer")
        {
            this.Content (o);
        }
    }

    public partial class Button : ContentControl, IButton
    {
        public Button() : base ("Button") { }
        public Button(object o) : base ("Button")
        {
            this.Content (o);
        }
        public Button(IElement element) : base ("Button")
        {
            this.Content (element);
        }
        public Button(object o, RoutedEventHandler handler) : base ("Button")
        {
            this.Content (o);
            this.AddEvent ("Click", handler);
        }
        public Button(IElement element, RoutedEventHandler handler) : base ("Button")
        {
            this.Content (element);
            this.AddEvent ("Click", handler);
        }
    }
    public partial class VStack : Panel, IVisual
    {
        public VStack() : base ("StackPanel")
        {
            this.SetProperty ("Orientation", System.Windows.Controls.Orientation.Vertical);
        }
        public VStack(params IElement[] node) : base ("StackPanel", node)
        {
            this.SetProperty ("Orientation", System.Windows.Controls.Orientation.Vertical);
        }
    }

    public partial class HStack : Panel, IVisual
    {
        public HStack() : base ("StackPanel")
        {
            this.SetProperty ("Orientation", System.Windows.Controls.Orientation.Horizontal);
        }
        public HStack(params IElement[] node) : base ("StackPanel", node)
        {
            this.SetProperty ("Orientation", System.Windows.Controls.Orientation.Horizontal);
        }
    }

    public partial class Text : Visual
    {
        public Text() : base ("TextBlock") { }
        public Text(string o) : base ("TextBlock")
        {
            this.SetProperty ("Text", o);
        }
    }

    public partial class Input : Visual, IInput
    {
        public Input() : base ("TextBox")
        {
            this.SetProperty ("VerticalContentAlignment", System.Windows.VerticalAlignment.Center);
        }
    }
}
