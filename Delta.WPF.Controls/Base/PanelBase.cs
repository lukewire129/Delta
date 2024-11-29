using Delta.WPF.Controls.Diffing;

namespace Delta.WPF.Controls.Base
{
    public abstract class PanelBase : VisualNode
    {
        private readonly List<VisualNode> _children = new ();

        public PanelBase AddChild(VisualNode node)
        {
            _children.Add (node);
            return this;
        }

        protected List<VisualNode> GetChildren() => _children;

        public override List<DiffOperation> Diff(VisualNode newNode)
        {
            var operations = base.Diff (newNode);

            if (newNode is PanelBase newPanel)
            {
                var maxCount = Math.Max (_children.Count, newPanel._children.Count);

                for (int i = 0; i < maxCount; i++)
                {
                    if (i >= _children.Count)
                    {
                        // 새로운 자식 추가
                        operations.Add (new DiffOperation
                        {
                            Type = DiffOperationType.Add,
                            NewNode = newPanel._children[i]
                        });
                    }
                    else if (i >= newPanel._children.Count)
                    {
                        // 기존 자식 제거
                        operations.Add (new DiffOperation
                        {
                            Type = DiffOperationType.Remove,
                            OldNode = _children[i]
                        });
                    }
                    else
                    {
                        // 기존 자식과 새로운 자식 비교
                        operations.AddRange (_children[i].Diff (newPanel._children[i]));
                    }
                }
            }

            return operations;
        }
    }
}
