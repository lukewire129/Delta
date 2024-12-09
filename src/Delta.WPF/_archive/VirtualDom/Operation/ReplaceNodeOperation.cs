using Delta;
namespace Delta.WPF
{
    public class ReplaceNodeOperation : DiffOperation
    {
        public string TargetId { get; }
        public IElement NewNode { get; }

        public ReplaceNodeOperation(string targetId, IElement newNode)
        {
            TargetId = targetId;
            NewNode = newNode;
        }
    }
}
