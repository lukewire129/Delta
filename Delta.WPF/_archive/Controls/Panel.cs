using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delta.WPF
{
    public class Panel : Visual
    {
        public Panel(string type) : base (type)
        {
        }

        public Panel(string type, params IElement[] node) : this (type)
        {
            AddChild (node);
        }

        public void AddChild(IElement[] child)
        {
            foreach (IElement element in child)
            {
                if (element is Component component)
                {
                    // 부모에서 자식의 Render 결과를 자동 추가
                    var renderedChild = component.RenderTree ();
                    this.Children.Add (renderedChild);
                }
                else
                {
                    this.Children.Add (element);
                }
            }
        }
    }
}
