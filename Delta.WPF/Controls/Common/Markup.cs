namespace Delta.WPF
{
    public static partial class Markup
    {
        public static VirtualNode Content(this VirtualNode node, object content)
        {
            return node.SetProperty ("Content", content);
        }

        public static VirtualNode Width(this VirtualNode node, double width)
        {
            return node.SetProperty ("Width", width);
        }

        public static VirtualNode Height(this VirtualNode node, double height)
        {
            return node.SetProperty ("Height", height);
        }

        public static VirtualNode Text(this VirtualNode node, string text)
        {
            return node.SetProperty ("Text", text);
        }

        public static VirtualNode Children(this VirtualNode node, params VirtualNode[] children)
        {
            foreach (var child in children)
            {
                node.AddChild (child);
            }
            return node;
        }
    }
}
