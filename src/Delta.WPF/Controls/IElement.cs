using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Delta.WPF
{
    public interface IElement
    {
        string ParentId { get; set; }
        string Id { get; set; }
        string Type { get; set; }
        string Name { get; set; }
        bool TryGetValue(string propertyName, [MaybeNullWhen (false)] out object value);
        public List<IElement> Children { get; set; }
        Dictionary<string, object> Properties { get; set; }
        IElement SetProperty(string name, object value);
        public Dictionary<string, Delegate> Events { get; set; }
        bool Equals(object obj);
        public void LoadNodeNumber(string parentId, int myId);
        IElement AddEvent(string eventName, Delegate handler);
    }
}
