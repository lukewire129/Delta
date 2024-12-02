using System;

namespace Delta.WPF
{
    public static class DeltaControl
    {
        public static VStack VStack(params VisualNode?[]? children)
        {
            VStack vStack = new VStack ();
            if (children != null)
            {
                vStack.AddChild (children);
            }

            return vStack;
        }

        public static HStack HStack(params VisualNode?[]? children)
        {
            HStack hStack = new HStack ();
            if (children != null)
            {
                hStack.AddChild (children);
            }

            return hStack;
        }

        public static Button Button(VisualNode content, Action onClick)
        {
            return new Button (content, onClick);
        }

        public static Button Button(string content, Action onClick)
        {
            return new Button (content, onClick);
        }

        public static Grid Grid(params VisualNode?[]? children)
        {
            Grid grd = new Grid ();
            if (children != null)
            {
                grd.AddChild (children);
            }

            return grd;
        }
    }
}
