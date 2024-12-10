using Delta;
namespace Delta.WPF
{
    public class AddChildOperation : DiffOperation
    {
        public string ParentKey { get; }
        public IElement ChildNode { get; }

        public AddChildOperation(string ParentKey, IElement childNode)
        {
            ParentKey = ParentKey;
            ChildNode = childNode;
        }
    }
}
