using System.Windows;

namespace Delta.WPF
{
    public interface IRadio : IVisual
    {

    }
    public abstract partial class Component
    {
        public static Radio Radio()
        {
            return new Radio ();
        }
        public static Radio Radio(object o)
        {
            return new Radio (o);
        }
        public static Radio Radio(IElement element)
        {
            return new Radio (element);
        }
    }
    public partial class Radio : ContentControl, IFont, IRadio, IButton
    {
        public Radio() : base ("RadioButton")
        {
        }
        public Radio(object o) : base ("RadioButton")
        {
            this.Content (o);
        }
        public Radio(IElement element) : base ("RadioButton")
        {
            this.Content (element);
        }
    }

    public static partial class RadioVisualExtention
    {
        public static T OnChanged<T>(this T node, RoutedEventHandler handlerFactory) where T : IRadio
        {
            node.AddEvent ("Checked", handlerFactory);
            node.AddEvent ("Unchecked", handlerFactory);

            return node;
        }
        public static T Group<T>(this T node, string groupName) where T : IRadio
        {
            node.SetProperty ("GroupName", groupName);

            return node;
        }
    }
}
