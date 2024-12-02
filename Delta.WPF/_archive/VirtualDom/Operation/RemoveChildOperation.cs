using Delta;
namespace Delta.WPF
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
