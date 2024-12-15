using System;
using System.Windows;
using System.Windows.Input;

namespace Delta.WPF
{
    public class VisualElement : Element
    {
        public VisualElement()
        {
        }

        public VisualElement(string nodeType) : this()
        {
            Type = nodeType;
            Console.WriteLine ($"VisualNode created with NodeType: {Type}");
        }

        public int GetHashCode()
        {
            int hash = Type.GetHashCode ();
            hash = (hash * 397) ^ Properties.GetHashCode ();
            foreach (var child in Children)
            {
                hash = (hash * 397) ^ child.GetHashCode ();
            }
            return hash;
        }
    }


    public static partial class VisualExtentions
    {
        public static T OnClick<T>(this T node, MouseButtonEventHandler handlerFactory) where T : IVisual
        {
            node.AddEvent ("MouseLeftButtonDown", handlerFactory);
            return node;
        }
    }

    public static class UniqueIdGenerator
    {
        private static long _currentId = 0;

        public static string GenerateId()
        {
            return $"node_{System.Threading.Interlocked.Increment (ref _currentId)}";
        }
    }
}
