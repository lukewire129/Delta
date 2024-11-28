namespace Delta
{
    public class RemoveChildOperation : DiffOperation
    {
        public string TargetId { get; }

        public RemoveChildOperation(string targetId)
        {
            TargetId = targetId;
        }
    }
}
