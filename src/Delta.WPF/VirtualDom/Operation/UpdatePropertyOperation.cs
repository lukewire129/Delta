using Delta;
namespace Delta.WPF
{
    public class UpdatePropertyOperation : DiffOperation
    {
        public string TargetId { get; }
        public string NewId { get; }
        public string PropertyName { get; }
        public object NewValue { get; }

        public UpdatePropertyOperation(string targetId, string newId, string propertyName, object newValue)
        {
            this.type = Enums.DiffOperationType.UpdateProperty;
            TargetId = targetId;
            NewId = newId;
            PropertyName = propertyName;
            NewValue = newValue;
        }
    }
}
