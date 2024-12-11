using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace Delta.WPF
{
    public class Element : FrameworkElement, IElement
    {
        public string ParentId { get; set; } = "0";
        public string Id { get; set; } = "0";
        public string Type { get; set; }
        public List<IElement> Children { get; set; } = new List<IElement>();
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object> ();

        public Dictionary<string, Delegate> Events { get; set; } = new Dictionary<string, Delegate> (); // 이벤트 저장

        public bool TryGetValue(string propertyName, [MaybeNullWhen (false)] out object value)
        {
            if (Properties.TryGetValue (propertyName, out var temp))
            {
                value = temp;
                return true;
            }

            value = default;
            return false;
        }

        public void LoadNodeNumber(string parentId, int myId)
        {
            ParentId = parentId;
            this.Id = $"{parentId}_{myId}";
        }
        public IElement SetProperty(string name, object value)
        {
            Properties[name] = value;
            return this;
        }

        public IElement AddEvent(string eventName, Delegate handler)
        {
            Events[eventName] = handler;
            return this;
        }

        public new bool Equals(object obj)
        {
            if (!(obj is Element other))
                return false;

            return Type == other.Type;
        }
    }
}
