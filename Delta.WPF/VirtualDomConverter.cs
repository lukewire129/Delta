using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Delta.WPF
{
    public static class VirtualDomConverter
    {
        public static VirtualNode ToVirtualNode(FrameworkElement element)
        {
            var node = new VirtualNode
            {
                Type = element.GetType ().Name,
                Properties = element.GetType ()
                                    .GetProperties ()
                                    .Where (p => p.CanRead && p.CanWrite)
                                    .ToDictionary (p => p.Name, p => p.GetValue (element)),
                Children = LogicalTreeHelper.GetChildren (element)
                                            .OfType<FrameworkElement> ()
                                            .Select (ToVirtualNode)
                                            .ToList ()
            };

            return node;
        }
    }
}
