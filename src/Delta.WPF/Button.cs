using System;
using System.Windows;

namespace Delta.WPF
{
    public class Button : VisualNode
    {
        private readonly VisualNode _content;
        private readonly Action _onClick;

        public Button(VisualNode content, Action onClick)
        {
            _content = content;
            _onClick = onClick;
        }

        public Button(string content, Action onClick)
            : this (new Text (content), onClick)
        {
        }

        public override UIElement CreateElement()
        {
            var button = new System.Windows.Controls.Button
            {
                Content = _content.CreateElement ()
            };
            // 이벤트 핸들러 추가
            button.Click += OnClickHandler;
            return button;
        }

        public override void DiffAndUpdate(UIElement element)
        {
            if (element is System.Windows.Controls.Button button)
            {
                UpdateElementProperties (button);

                // 기존 이벤트 핸들러 제거 후 새로 추가
                button.Click -= OnClickHandler;
                button.Click += OnClickHandler;

                if (button.Content is UIElement existingContent)
                {
                    _content.DiffAndUpdate (existingContent);
                }
                else
                {
                    button.Content = _content.CreateElement ();
                }
            }
        }
        private void OnClickHandler(object sender, RoutedEventArgs e)
        {
            _onClick?.Invoke ();
        }
    }
}
