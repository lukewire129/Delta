using System;
using System.Windows;

namespace Delta.WPF
{
    public class Control : VisualNode
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
        public static Button Button(object o)
        {
            return new Button (o);
        }
        public static Button Button(object o, RoutedEventHandler handlerFactory)
        {
            return new Button (o, handlerFactory);
        }
        public static VStack VStack(params VisualNode[] nodes)
        {
            return new VStack (nodes);
        }
        public static HStack HStack(params VisualNode[] nodes)
        {
            return new HStack (nodes);
        }
        public static Text Text()
        {
            return new Text ();
        }
        public static Text Text(object o)
        {
            return new Text (o);
        }
        public static Input Input()
        {
            return new Input ();
        }
    }
}
