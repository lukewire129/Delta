using Delta;
namespace Delta.WPF
{
    public class RemovePropertyOperation : DiffOperation
    {
        public string TargetId { get; }
        public string PropertyName { get; }

        public RemovePropertyOperation(string targetId, string propertyName)
        {
            this.type = Enums.DiffOperationType.RemoveEvent;

            TargetId = targetId;
            PropertyName = propertyName;
        }
    }
}
