using Delta;
namespace Delta.WPF
{
    public class AddChildOperation : DiffOperation
    {
        public string TargetId { get; }
        public VisualNode ChildNode { get; }

        public AddChildOperation(string targetId, VisualNode childNode)
        {
            TargetId = targetId;
            ChildNode = childNode;
        }
    }
}
