using System.Windows;

namespace Delta.WPF
{
    public abstract partial class Component
    {
        public static Button Button()
        {
            return new Button ();
        }
        public static Button Button(IElement o)
        {
            return new Button (o);
        }
        public static Button Button(object o, RoutedEventHandler handler)
        {
            return new Button (o, handler);
        }
        public static Button Button(IElement o, RoutedEventHandler handler)
        {
            return new Button (o, handler);
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
        public static Radio Radio()
        {
            return new Radio ();
        }

        public static Check Check()
        {
            return new Check ();
        }
        public static Radio Radio(IElement o)
        {
            return new Radio (o);
        }

        public static Check Check(IElement o)
        {
            return new Check (o);
        }

        public static Scroll Scroll(IElement o)
        {
            return new Scroll (o);
        }
    }
}
