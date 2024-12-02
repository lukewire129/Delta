using System.Windows;

namespace Delta.WPF
{
    public class Text : VisualNode
    {
        private readonly string _text;

        public Text(string text)
        {
            _text = text;
        }

        public override UIElement CreateElement()
        {
            return new System.Windows.Controls.TextBlock { Text = _text };
        }

        public override void DiffAndUpdate(UIElement element)
        {
            UpdateElementProperties (element);

            //if (element is System.Windows.Controls.TextBlock textBlock && textBlock.Text != _text)
            //{
            //    textBlock.Text = _text;
            //}
        }
    }
}
