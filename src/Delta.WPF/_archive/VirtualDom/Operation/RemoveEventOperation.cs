using System;
using System.Collections.Generic;

namespace Delta.WPF
{
    public class RemoveEventOperation : DiffOperation
    {
        public IElement OldNode { get; }
        public KeyValuePair<string, Delegate> Event { get; }
        public RemoveEventOperation(IElement oldNode, KeyValuePair<string, Delegate> eventd)
        {
            OldNode = oldNode;
            Event = eventd;
        }

    }
    public class AddEventOperation : DiffOperation
    {
        public AddEventOperation(IElement newNode, KeyValuePair<string, Delegate> eventd)
        {
            NewNode = newNode;
            Event = eventd;
        }

        public IElement NewNode { get; }
        public KeyValuePair<string, Delegate> Event { get; }
    }
}
