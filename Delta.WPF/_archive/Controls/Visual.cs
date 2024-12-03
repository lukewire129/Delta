using System.Windows;

namespace Delta.WPF
{
    public class Visual : VisualNode, IVisual
    {
        public Visual(string type) : base(type) { }
        public VisualNode Height(double value)
        {
            return this.SetProperty ("Height", value);
        }

        public VisualNode Margin(Thickness value)
        {
            return this.SetProperty ("Margin", value);
        }

        public VisualNode Width(double value)
        {
            return this.SetProperty ("Width", value);
        }
    }
}
