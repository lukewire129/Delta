using System;
using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF
{
    public interface ICheck : IVisual
    {

    }

    public abstract partial class Component
    {
        public static Check Check()
        {
            return new Check ();
        }

        public static Check Check(object o)
        {
            return new Check (o);
        }

        public static Check Check(IElement element)
        {
            return new Check (element);
        }
    }

    public partial class Check : ContentControl, ICheck, IButton
    {
        public Check() : base ("CheckBox")
        {
        }
        public Check(object o) : base ("CheckBox")
        {
            this.Content (o);
        }
        public Check(IElement element) : base ("CheckBox")
        {
            this.Content (element);
        }
    }

    public static partial class CheckVisualExtention
    {
        
    }
}
