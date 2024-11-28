namespace Delta.WPF
{
    public class Visual : VisualNode, IVisual<VisualNode>
    {
        public Visual(string type) : base(type) { }
        public VisualNode Height(double value)
        {
            return this.SetProperty ("Height", value);
        }

        public VisualNode Width(double value)
        {
            return this.SetProperty ("Width", value);
        }
    }
}
