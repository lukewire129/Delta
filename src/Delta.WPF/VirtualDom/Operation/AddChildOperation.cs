using Delta;
namespace Delta.WPF
{
    public class AddChildOperation : DiffOperation
    {
        public IElement ChildNode { get; }

        public AddChildOperation(IElement childNode)
        {
            ChildNode = childNode;
        }
    }
}
