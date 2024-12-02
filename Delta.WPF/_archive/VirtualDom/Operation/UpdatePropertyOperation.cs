using Delta;
namespace Delta.WPF
{
    public class UpdatePropertyOperation : DiffOperation
    {
        public string TargetId { get; }
        public string PropertyName { get; }
        public object NewValue { get; }

        public UpdatePropertyOperation(string targetId, string propertyName, object newValue)
        {
            TargetId = targetId;
            PropertyName = propertyName;
            NewValue = newValue;
        }
    }
}
