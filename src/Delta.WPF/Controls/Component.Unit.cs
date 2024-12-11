using System.Windows;
using System.Xml.Linq;

namespace Delta.WPF
{
    public abstract partial class Component
    {
        public static Button Button()
        {
            return new Button ();
        }
        public static Button Button(IElement element)
        {
            return new Button (element);
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
        public static Radio Radio(object o)
        {
            return new Radio (o);
        }

        public static Check Check(object o)
        {
            return new Check (o);
        }
        public static Radio Radio(IElement element)
        {
            return new Radio (element);
        }

        public static Check Check(IElement element)
        {
            return new Check (element);
        }

        public static Scroll Scroll(IElement element)
        {
            return new Scroll (element);
        }

        public static Img Img()
        {
            return new Img ();
        }
        public static Img Img(string sourcePath)
        {
            return new Img(sourcePath);
        }
    }
}
