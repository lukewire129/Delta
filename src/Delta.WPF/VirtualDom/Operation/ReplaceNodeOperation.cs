using Delta;
namespace Delta.WPF
{
    public class ReplaceNodeOperation : DiffOperation
    {
        public IElement Node { get; }

        public ReplaceNodeOperation(IElement newNode)
        {
            Node = newNode;
        }
    }
}
