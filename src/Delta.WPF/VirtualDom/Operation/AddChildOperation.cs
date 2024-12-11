namespace Delta.WPF
{
    public class AddChildOperation : DiffOperation
    {
        public IElement ChildNode { get; }

        public AddChildOperation(IElement childNode)
        {
            this.type = Enums.DiffOperationType.AddChild;
            ChildNode = childNode;
        }
    }
}
