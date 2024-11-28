namespace Delta.WPF
{
    public class Element : VisualNode
    {
        public static Grid Grid()
        {
            return new Grid ();
        }
        public static Grid Grid(params VisualNode[] nodes)
        {
            return new Grid (nodes);
        }
        public static Button Button()
        {
            return new Button ();
        }
        public static VStack VStack()
        {
            return new VStack ();
        }
        public static HStack HStack()
        {
            return new HStack ();
        }
        public static Text Text()
        {
            return new Text ();
        }
        public static Input Input()
        {
            return new Input ();
        }
    }
}
