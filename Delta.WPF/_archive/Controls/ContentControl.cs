namespace Delta.WPF
{
    public class ContentControl : Visual, IContent
    {
        public ContentControl(string type) : base(type) { }
        public VisualNode Content(object o)
        {
            return this.SetProperty ("Content", o);
        }
    }
}
