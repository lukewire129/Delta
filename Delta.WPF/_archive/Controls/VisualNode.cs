using System;
using System.Collections.Generic;

namespace Delta.WPF
{
    public partial class VisualNode : IVisual
    {
        public string Id { get; } = UniqueIdGenerator.GenerateId (); // 고유 ID 생성
        public string Type { get; set; }
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object> ();
        public List<IVisual> Children { get; set; } = new List<IVisual> ();
        public Dictionary<string, Delegate> Events { get; set; } = new Dictionary<string, Delegate> (); // 이벤트 저장

        // Fluent API로 속성 설정
        public VisualNode SetProperty(string name, object value)
        {
            Properties[name] = value;
            return this;
        }

        // 자식 노드 추가
        public VisualNode AddChild(VisualNode child)
        {
            Children.Add (child);
            return this;
        }
        public VisualNode()
        {
            this.Id = UniqueIdGenerator.GenerateId ();
        }

        // 정적 팩토리 메서드로 노드 생성
        public static VisualNode Create(string type)
        {
            return new VisualNode { Type = type };
        }

        public VisualNode(string nodeType)
        {
            Type = nodeType;
            Console.WriteLine ($"VisualNode created with NodeType: {Type}");
        }

        public VisualNode AddEvent(string eventName, Delegate handler)
        {
            Events[eventName] = handler;
            return this;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is VisualNode other))
                return false;

            return Type == other.Type;
        }

        public override int GetHashCode()
        {
            int hash = Type.GetHashCode ();
            hash = (hash * 397) ^ Properties.GetHashCode ();
            foreach (var child in Children)
            {
                hash = (hash * 397) ^ child.GetHashCode ();
            }
            return hash;
        }
        private static bool ChildrenEqual(List<VisualNode> children1, List<VisualNode> children2)
        {
            if (children1.Count != children2.Count)
                return false;

            for (int i = 0; i < children1.Count; i++)
            {
                if (!children1[i].Equals (children2[i]))
                    return false;
            }

            return true;
        }
    }
    public static class UniqueIdGenerator
    {
        private static long _currentId = 0;

        public static string GenerateId()
        {
            return $"node_{System.Threading.Interlocked.Increment (ref _currentId)}";
        }
    }
}
