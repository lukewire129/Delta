using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delta.WPF._archive.Controls.Extentions;
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
            int parentId = this.ParentId;
            int id = 1;
            foreach (IElement element in child)
            {
                if (element is Component component)
                {
                    element.LoadNodeNumber (parentId, id);
                    // 부모에서 자식의 Render 결과를 자동 추가
                    var renderedChild = component.Render ();

                    var temp = element.GetAttachedProperty ();
                    foreach (var item in temp)
                    {
                        renderedChild.Properties.Add (item.Key, item.Value);
                    }
                    renderedChild.LoadNodeNumber(parentId, id);

                    ChildrenId (id, renderedChild);
                    this.Children.Add (renderedChild);
                }
                else
                {
                    element.LoadNodeNumber (parentId, id);

                    if(element.Children.Count >0)
                    {
                        ChildrenId (id, element);
                    }
                    this.Children.Add (element);
                }
                id++;
            }
        }

        private void ChildrenId(int parentId, IElement element)
        {
            int id = 1;
            foreach (var children in element.Children)
            {
                children.LoadNodeNumber (parentId, id++);
            }
        }
    }
}
