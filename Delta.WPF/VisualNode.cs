using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Delta.WPF
{
    public abstract class VisualNode : VisualNode<UIElement>
    {
        public List<VisualNode> Children { get; } = new ();

        public virtual void DiffAndUpdate(UIElement element)
        {
            UpdateElementProperties (element);

            if (element is System.Windows.Controls.Panel panel)
            {
                SyncChildren (panel);
            }
            else if (element is ContentControl contentControl)
            {
                SyncContentControl (contentControl);
            }
        }

        protected virtual void UpdateElementProperties(UIElement element)
        {
            var elementType = element.GetType ();
            var nodeType = GetType ();

            foreach (var property in elementType.GetProperties (BindingFlags.Public | BindingFlags.Instance))
            {
                if (!property.CanRead || !property.CanWrite || property.GetIndexParameters ().Length > 0)
                    continue;

                var nodeValue = nodeType.GetProperty (property.Name)?.GetValue (this);
                var elementValue = property.GetValue (element);

                if (nodeValue != null && !Equals (elementValue, nodeValue))
                {
                    property.SetValue (element, nodeValue);
                }
            }
        }

        private void SyncChildren(System.Windows.Controls.Panel panel)
        {
            var existingChildren = panel.Children.Cast<UIElement> ().ToList ();
            var newChildren = Children.Select (child => child.CreateElement ()).ToList ();

            // Remove excess elements
            for (int i = existingChildren.Count - 1; i >= newChildren.Count; i--)
            {
                panel.Children.RemoveAt (i);
            }

            // Update or add elements
            for (int i = 0; i < newChildren.Count; i++)
            {
                if (i < existingChildren.Count)
                {
                    Children[i].DiffAndUpdate (existingChildren[i]);
                }
                else
                {
                    panel.Children.Add (newChildren[i]);
                }
            }
        }

        private void SyncContentControl(ContentControl contentControl)
        {
            if (Children.Count == 1)
            {
                var newChildElement = Children[0].CreateElement ();
                if (contentControl.Content is UIElement existingContent)
                {
                    Children[0].DiffAndUpdate (existingContent);
                }
                else
                {
                    contentControl.Content = newChildElement;
                }
            }
            else if (Children.Count == 0)
            {
                contentControl.Content = null;
            }
            else
            {
                throw new InvalidOperationException ("ContentControl can only have one child.");
            }
        }
    }
}
