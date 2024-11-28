namespace Delta
{
    public class AddChildOperation : DiffOperation
    {
        public string TargetId { get; }
        public VirtualNode ChildNode { get; }

        public AddChildOperation(string targetId, VirtualNode childNode)
        {
            TargetId = targetId;
            ChildNode = childNode;
        }
    }
}
