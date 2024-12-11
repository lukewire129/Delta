using Delta;
namespace Delta.WPF
{
    public class RemoveChildOperation : DiffOperation
    {
        public IElement Target { get; }

        public RemoveChildOperation(IElement target)
        {
            Target = target;
        }
    }
}
