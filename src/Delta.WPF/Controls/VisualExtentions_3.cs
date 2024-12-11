namespace Delta.WPF
{
    public static partial class VisualExtention
    {
        public static IElement Group(this IRadio node, string groupName)  => node.Group (groupName);

        public static IElement Source(this IImage node, string sourcePath) => node.Source (sourcePath);
    }
}
