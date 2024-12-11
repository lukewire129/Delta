namespace Delta.WPF
{
    public static partial class VisualExtention
    {
        public static IElement Group<T>(this T node, string groupName) where T : IRadio
        {
            return node.SetProperty ("GroupName", groupName);
        }
    }
}
