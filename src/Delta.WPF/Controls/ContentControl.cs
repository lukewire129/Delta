using System;

namespace Delta.WPF
{
    public class ContentControl : Visual, IContent
    {
        public ContentControl(string type) : base(type) { }
        public IElement Content(IElement element)
        {
            element.LoadNodeNumber (this.Id, 1);
            this.Children.Add (element);
            return this;
        }
        public IElement Content(object o)
        {
            return this.SetProperty ("Content", o);
        }
    }
}
