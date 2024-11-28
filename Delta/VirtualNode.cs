using System;
using System.Collections.Generic;

namespace Delta
{
    public class VirtualNode
    {
        public string Id { get; } = UniqueIdGenerator.GenerateId (); // 고유 ID 생성
        public string Type { get; set; }
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object> ();
        public List<VirtualNode> Children { get; set; } = new List<VirtualNode>();
        public Dictionary<string, Delegate> Events { get; set; } = new Dictionary<string, Delegate> (); // 이벤트 저장

        // Fluent API로 속성 설정
        public VirtualNode SetProperty(string name, object value)
        {
            Properties[name] = value;
            return this;
        }

        // 자식 노드 추가
        public VirtualNode AddChild(VirtualNode child)
        {
            Children.Add (child);
            return this;
        }
        public VirtualNode()
        {
            this.Id = UniqueIdGenerator.GenerateId ();
        }
        // 정적 팩토리 메서드로 노드 생성
        public static VirtualNode Create(string type)
        {
            return new VirtualNode { Type = type };
        }

        public VirtualNode AddEvent(string eventName, Delegate handler)
        {
            Events[eventName] = handler;
            return this;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is VirtualNode other))
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
        private static bool ChildrenEqual(List<VirtualNode> children1, List<VirtualNode> children2)
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
