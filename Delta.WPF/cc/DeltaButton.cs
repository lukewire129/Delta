using System;
using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF.cc
{
    public class DeltaButton : VisualNode
    {
        private readonly string _content;
        private readonly Action _onClick;

        public DeltaButton(string content, Action onClick)
        {
            _content = content;
            _onClick = onClick;
        }
        public override UIElement CreateElement()
        {
            var button = new Button
            {
                Content = _content
            };
            button.Click += (s, e) => _onClick ();
            return button;
        }
    }
}
