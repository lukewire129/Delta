namespace Delta
{
    public class ReplaceNodeOperation : DiffOperation
    {
        public string TargetId { get; }
        public VirtualNode NewNode { get; }

        public ReplaceNodeOperation(string targetId, VirtualNode newNode)
        {
            TargetId = targetId;
            NewNode = newNode;
        }
    }
}
