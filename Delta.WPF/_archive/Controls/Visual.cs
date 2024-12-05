using System.Windows;

namespace Delta.WPF
{
    public class Visual : VisualElement, IVisual
    {
        public Visual(string type) : base(type) { }
        public IElement Height(double value)
        {
            return this.SetProperty ("Height", value);
        }

        public IElement Margin(Thickness value)
        {
            return this.SetProperty ("Margin", value);
        }

        public IElement Width(double value)
        {
            return this.SetProperty ("Width", value);
        }
    }
}
