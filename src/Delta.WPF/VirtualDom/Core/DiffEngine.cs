using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Delta.WPF
{
    public static class DiffEngine
    {
        public static List<DiffOperation> Diff(IElement oldNode, IElement newNode)
        {
            var operations = new List<DiffOperation> ();

            // 타입이나 구조가 다른 경우, ReplaceNode로 처리
            if (!oldNode.Equals (newNode))
            {
                foreach (var oldEvent in oldNode.Events)
                {
                    // 기존 핸들러 제거
                    operations.Add (new RemoveEventOperation (oldNode, oldEvent));
                }
                operations.Add (new ReplaceNodeOperation (newNode));
                return operations;
            }

            if (oldNode != null && newNode != null)
            {
                foreach (var oldEvent in oldNode.Events)
                {
                    if (!newNode.Events.ContainsKey (oldEvent.Key) ||
                        newNode.Events[oldEvent.Key] != oldEvent.Value)
                    {
                        // 기존 핸들러 제거
                        operations.Add (new RemoveEventOperation (oldNode, oldEvent));
                    }
                }

                foreach (var newEvent in newNode.Events)
                {
                    if (!oldNode.Events.ContainsKey (newEvent.Key) ||
                        oldNode.Events[newEvent.Key] != newEvent.Value)
                    {
                        // 새로운 핸들러 추가
                        operations.Add (new AddEventOperation (oldNode, newEvent));
                    }
                }
            }

            foreach (var property in newNode.Properties)
            {
                if (!oldNode.Properties.TryGetValue (property.Key, out var oldValue))
                {
                    // 기존 속성이 없으면 UpdatePropertyOperation 추가
                    operations.Add (new UpdatePropertyOperation (oldNode.Id, newNode.Id, property.Key, property.Value));
                    continue;
                }

                // RowDefinitions 또는 ColumnDefinitions 비교
                if (property.Value is List<RowDefinition> newRowDefs && oldValue is List<RowDefinition> oldRowDefs)
                {
                    if (!CollectionsEqual (newRowDefs, oldRowDefs, AreRowDefinitionsEqual))
                    {
                        operations.Add (new UpdatePropertyOperation (oldNode.Id, newNode.Id, property.Key, property.Value));
                    }
                }
                else if (property.Value is List<ColumnDefinition> newColDefs && oldValue is List<ColumnDefinition> oldColDefs)
                {
                    if (!CollectionsEqual (newColDefs, oldColDefs, AreColumnDefinitionsEqual))
                    {
                        operations.Add (new UpdatePropertyOperation (oldNode.Id, newNode.Id, property.Key, property.Value));
                    }
                }
                else if (!Equals (oldValue, property.Value))
                {
                    // 일반 값 비교
                    operations.Add (new UpdatePropertyOperation (oldNode.Id, newNode.Id, property.Key, property.Value));
                }
            }

            // 삭제된 속성 처리
            foreach (var property in oldNode.Properties)
            {
                if (!newNode.Properties.ContainsKey (property.Key))
                {
                    operations.Add (new RemovePropertyOperation (oldNode.Id, property.Key));
                }
            }

            // 자식 노드 비교
            var unmatchedOldChildren = oldNode.Children.ToList ();
            var unmatchedNewChildren = newNode.Children.ToList ();

            foreach (var newChild in newNode.Children)
            {
                var matchingOldChild = unmatchedOldChildren
                    .FirstOrDefault (oldChild => oldChild.Equals (newChild));

                if (matchingOldChild != null)
                {
                    operations.AddRange (Diff (matchingOldChild, newChild));
                    unmatchedOldChildren.Remove (matchingOldChild);
                    unmatchedNewChildren.Remove (newChild);
                }
            }

            foreach (var unmatchedOldChild in unmatchedOldChildren)
            {
                operations.Add (new RemoveChildOperation (unmatchedOldChild));
            }

            foreach (var unmatchedNewChild in unmatchedNewChildren)
            {
                operations.Add (new AddChildOperation (unmatchedNewChild));
                foreach (var children in unmatchedNewChild.Children)
                {
                    foreach (var newEvent in children.Events)
                    {
                        operations.Add (new AddEventOperation (children, newEvent));
                    }
                }
            }

            return operations;
        }

        private static bool AreRowDefinitionsEqual(RowDefinition row1, RowDefinition row2)
        {
            return Equals (row1.Height, row2.Height) &&
                   Equals (row1.MinHeight, row2.MinHeight) &&
                   Equals (row1.MaxHeight, row2.MaxHeight);
        }
        private static bool AreColumnDefinitionsEqual(ColumnDefinition col1, ColumnDefinition col2)
        {
            return Equals (col1.Width, col2.Width) &&
                   Equals (col1.MinWidth, col2.MinWidth) &&
                   Equals (col1.MaxWidth, col2.MaxWidth);
        }
        private static bool CollectionsEqual<T>(List<T> collection1, List<T> collection2, Func<T, T, bool> comparer)
        {
            if (collection1.Count != collection2.Count)
                return false;

            for (int i = 0; i < collection1.Count; i++)
            {
                if (!comparer (collection1[i], collection2[i]))
                    return false;
            }

            return true;
        }
    }
}
