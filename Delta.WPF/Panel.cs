using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Delta.WPF
{
    public class Panel : VisualNode
    {
        public override UIElement CreateElement()
        {
            throw new NotImplementedException ();
        }

        public void AddChild(params VisualNode[] nodes)
        {
            foreach (var node in nodes)
            {
                Children.Add (node);
            }
        }
    }
}
