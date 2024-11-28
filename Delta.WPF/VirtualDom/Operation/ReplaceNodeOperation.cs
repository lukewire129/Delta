using Delta;
namespace Delta.WPF
{
    public class ReplaceNodeOperation : DiffOperation
    {
        public string TargetId { get; }
        public VisualNode NewNode { get; }

        public ReplaceNodeOperation(string targetId, VisualNode newNode)
        {
            TargetId = targetId;
            NewNode = newNode;
        }
    }
}
