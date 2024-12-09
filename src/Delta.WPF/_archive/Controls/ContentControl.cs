namespace Delta.WPF
{
    public class ContentControl : Visual, IContent
    {
        public ContentControl(string type) : base(type) { }
        public IElement Content(object o)
        {
            return this.SetProperty ("Content", o);
        }
    }
}
