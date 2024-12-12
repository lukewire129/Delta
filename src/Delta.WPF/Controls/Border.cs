namespace Delta.WPF
{
    public interface IBorder : IVisual
    {

    }

    public partial class Border : ContentControl, IBorder
    {
        public Border(IElement element) : base ("Border")
        {
            this.Content (element);
        }
        public Border(object o) : base ("Border")
        {
            this.Content (o);
        }
    }
}
