namespace Delta.WPF
{
    public class ReplaceNodeOperation : DiffOperation
    {
        public IElement Node { get; }

        public ReplaceNodeOperation(IElement newNode)
        {
            this.type = Enums.DiffOperationType.ReplaceNode;
            Node = newNode;
        }
    }
}
