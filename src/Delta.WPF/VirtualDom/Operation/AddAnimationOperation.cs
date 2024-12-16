using System.Collections.Generic;
using System.Windows.Media.Animation;

namespace Delta.WPF.VirtualDom.Operation
{
    public class AddAnimationOperation : DiffOperation
    {
        public AddAnimationOperation(IElement newNode, KeyValuePair<string, AnimationTimeline> animation)
        {
            this.type = Enums.DiffOperationType.AddAnimation;

            NewNode = newNode;
            Animation = animation;
        }

        public IElement NewNode { get;  }
        public KeyValuePair<string, AnimationTimeline> Animation { get; }
    }

    public class RemoveAnimationOperation : DiffOperation
    {
        public RemoveAnimationOperation(IElement newNode, KeyValuePair<string, AnimationTimeline> animation)
        {
            this.type = Enums.DiffOperationType.AddAnimation;

            NewNode = newNode;
            Animation = animation;
        }

        public IElement NewNode { get; }
        public KeyValuePair<string, AnimationTimeline> Animation { get; }
    }
}
