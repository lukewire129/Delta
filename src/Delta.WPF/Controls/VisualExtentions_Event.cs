using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Delta.WPF
{
    public static partial class VisualExtention
    {
        public static T OnClick<T>(this T node, MouseButtonEventHandler handlerFactory) where T : IVisual
        {
            node.AddEvent ("MouseLeftButtonDown", handlerFactory);
            return node;
        }
        public static T OnClick<T>(this T node, RoutedEventHandler handlerFactory) where T : IButton
        {
            node.AddEvent ("Click", handlerFactory);
            return node;
        }
        public static T OnHover<T>(this T node, MouseEventHandler handlerFactory) where T : IVisual
        {
            node.AddEvent ("MouseEnter", handlerFactory);
            node.AddEvent ("MouseLeave", handlerFactory);

            return node;
        }

        public static IElement OnTextChanged<T>(this T node, Action<string> valueChangedHandler) where T : IInput
        {
            // TextChanged 이벤트를 추가하고, 텍스트 값을 직접 전달
            return node.AddEvent ("TextChanged", new TextChangedEventHandler ((s, e) =>
            {
                if (s is TextBox textBox)
                {
                    valueChangedHandler (textBox.Text); // 텍스트 값을 전달
                }
            }));
        }

        public static IElement OnContentChanged<T>(this T node, Action<object> valueChangedHandler) where T : IContent
        {
            return node.AddEvent ("ContentChanged", new RoutedEventHandler ((s, e) =>
            {
                if (s is System.Windows.Controls.ContentControl cc)
                {
                    valueChangedHandler (cc.Content); // 텍스트 값을 전달
                }
            }));
        }

        public static IElement OnCheckChanged<T>(this T node, Action<bool> valueChangedHandler) where T : ICheck
        {
            // TextChanged 이벤트를 추가하고, 텍스트 값을 직접 전달
            node.AddEvent ("Checked", new RoutedEventHandler ((s, e) =>
            {
                if (s is CheckBox cb)
                {
                    valueChangedHandler (cb.IsChecked.Value); // 텍스트 값을 전달
                }
                else if (s is RadioButton rb)
                {
                    valueChangedHandler (rb.IsChecked.Value); // 텍스트 값을 전달
                }
            }));
            return node.AddEvent ("Unchecked", new RoutedEventHandler ((s, e) =>
            {
                if (s is CheckBox cb)
                {
                    valueChangedHandler (cb.IsChecked.Value); // 텍스트 값을 전달
                }
                else if (s is RadioButton rb)
                {
                    valueChangedHandler (rb.IsChecked.Value); // 텍스트 값을 전달
                }
            }));
        }
    }
}
