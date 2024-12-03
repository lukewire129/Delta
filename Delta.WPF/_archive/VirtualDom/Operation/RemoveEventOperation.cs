using System;
using System.Collections.Generic;

namespace Delta.WPF
{
    public class RemoveEventOperation : DiffOperation
    {
        public IVisual OldNode { get; }
        public KeyValuePair<string, Delegate> Event { get; }
        public RemoveEventOperation(IVisual oldNode, KeyValuePair<string, Delegate> eventd)
        {
            OldNode = oldNode;
            Event = eventd;
        }

    }
    public class AddEventOperation : DiffOperation
    {
        public AddEventOperation(IVisual newNode, KeyValuePair<string, Delegate> eventd)
        {
            NewNode = newNode;
            Event = eventd;
        }

        public IVisual NewNode { get; }
        public KeyValuePair<string, Delegate> Event { get; }
    }
}
