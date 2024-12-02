using System;
using System.Collections.Generic;

namespace Delta.WPF
{
    public class RemoveEventOperation : DiffOperation
    {
        public VisualNode OldNode { get; }
        public KeyValuePair<string, Delegate> Event { get; }
        public RemoveEventOperation(VisualNode oldNode, KeyValuePair<string, Delegate> eventd)
        {
            OldNode = oldNode;
            Event = eventd;
        }

    }
    public class AddEventOperation : DiffOperation
    {
        public AddEventOperation(VisualNode newNode, KeyValuePair<string, Delegate> eventd)
        {
            NewNode = newNode;
            Event = eventd;
        }

        public VisualNode NewNode { get; }
        public KeyValuePair<string, Delegate> Event { get; }
    }
}
