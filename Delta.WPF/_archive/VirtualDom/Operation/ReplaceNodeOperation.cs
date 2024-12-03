using Delta;
namespace Delta.WPF
{
    public class ReplaceNodeOperation : DiffOperation
    {
        public string TargetId { get; }
        public IVisual NewNode { get; }

        public ReplaceNodeOperation(string targetId, IVisual newNode)
        {
            TargetId = targetId;
            NewNode = newNode;
        }
    }
}
