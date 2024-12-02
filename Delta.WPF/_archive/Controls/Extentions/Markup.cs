namespace Delta.WPF
{
    public static partial class Markup
    {
        public static T Content<T>(this T node, object content) where T : IContent<T>
        {
            return node.Content (content);
        }

        public static T Width<T>(this T node, double value) where T : IVisual<T>
        {
            return node.Width (value);
        }

        public static T Height<T>(this T node, double value) where T : IVisual<T>
        {
            return node.Height (value);
        }

        public static VisualNode Text(this VisualNode node, string text) 
        {
            return node.SetProperty ("Text", text);
        }

        public static VisualNode Children(this VisualNode node, params VisualNode[] children)
        {
            foreach (var child in children)
            {
                node.AddChild (child);
            }
            return node;
        }
    }
}
