using Delta;
namespace Delta.WPF
{
    public class AddChildOperation : DiffOperation
    {
        public string ParentKey { get; }
        public IVisual ChildNode { get; }

        public AddChildOperation(string ParentKey, IVisual childNode)
        {
            ParentKey = ParentKey;
            ChildNode = childNode;
        }
    }
}
