using Delta;
namespace Delta.WPF
{
    public class AddChildOperation : DiffOperation
    {
        public string ParentKey { get; }
        public VisualNode ChildNode { get; }

        public AddChildOperation(string ParentKey, VisualNode childNode)
        {
            ParentKey = ParentKey;
            ChildNode = childNode;
        }
    }
}
