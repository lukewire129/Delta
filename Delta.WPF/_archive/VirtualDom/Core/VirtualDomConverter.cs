using System.Linq;
using System.Windows;

namespace Delta.WPF
{
    public static class VirtualDomConverter
    {
        public static VisualNode ToVisualNode(FrameworkElement element)
        {
            var node = new VisualNode
            {
                Type = element.GetType ().Name,
                Properties = element.GetType ()
                                    .GetProperties ()
                                    .Where (p => p.CanRead && p.CanWrite)
                                    .ToDictionary (p => p.Name, p => p.GetValue (element)),
                Children = LogicalTreeHelper.GetChildren (element)
                                            .OfType<FrameworkElement> ()
                                            .Select (ToVisualNode)
                                            .ToList ()
            };

            return node;
        }
    }
}
