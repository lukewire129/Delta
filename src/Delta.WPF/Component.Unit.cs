using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF
{
    public abstract partial class Component
    {
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
        public static VStack VStack(params IElement[] nodes)
        {
            return new VStack (nodes);
        }
        public static HStack HStack(params IElement[] nodes)
        {
            return new HStack (nodes);
        }
        public static Text Text()
        {
            return new Text ();
        }
        public static Text Text(string o)
        {
            return new Text (o);
        }
        public static Input Input()
        {
            return new Input ();
        }
        public static Input Input(TextChangedEventHandler handlerFactory)
        {
            return new Input (handlerFactory);
        }
        public static Scroll Scroll(object o)
        {
            return new Scroll (o);
        }
    }
}
