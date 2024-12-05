using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace Delta.WPF
{
    public static class RenderingEngine
    {
        public static void ApplyDiff(FrameworkElement root, List<DiffOperation> operations)
        {
            foreach (var operation in operations)
            {
                switch (operation)
                {
                    case ReplaceNodeOperation replace:
                        ReplaceNode (root, replace);
                        break;
                    case UpdatePropertyOperation update:
                        UpdateProperty (root, update);
                        break;
                    case AddChildOperation add:
                        AddChild (root, add);
                        break;
                    case RemovePropertyOperation removeProperty:
                        RemoveProperty (root, removeProperty);
                        break;
                    case RemoveChildOperation removeChild:
                        RemoveChild (root, removeChild);
                        break;

                    case RemoveEventOperation removeEvent:
                        RemoveHandler (root, removeEvent);
                        break;

                    case AddEventOperation addEvent:
                        AddHandler (root, addEvent);
                        break;
                    default:
                        throw new InvalidOperationException ($"Unknown operation type: {operation.GetType ().Name}");
                }
            }
        }

        private static void RemoveHandler(FrameworkElement root, RemoveEventOperation operation)
        {
            var targetControl = FindControlById (root, operation.OldNode.Id);

            if (targetControl == null)
            {
                Console.WriteLine ($"Control with ID '{operation.OldNode.Id}' not found.");
                return;
            }

            var eventInfo = targetControl.GetType ().GetEvent (operation.Event.Key);
            if (eventInfo != null)
            {
                eventInfo.RemoveEventHandler (targetControl, operation.Event.Value);
            }
        }

        private static void AddHandler(FrameworkElement root, AddEventOperation operation)
        {
            var targetControl = FindControlById (root, operation.NewNode.Id);

            if (targetControl == null)
            {
                Console.WriteLine ($"Control with ID '{operation.NewNode.Id}' not found.");
                return;
            }

            var eventInfo = targetControl.GetType ().GetEvent (operation.Event.Key);
            if (eventInfo != null)
            {
                eventInfo.AddEventHandler(targetControl, operation.Event.Value);
            }
        }
        private static void ReplaceNode(FrameworkElement root, ReplaceNodeOperation operation)
        {
            var targetControl = FindControlById (root, operation.TargetId);

            if (targetControl == null)
            {
                Console.WriteLine ($"Control with ID '{operation.TargetId}' not found.");
                return;
            }

            if (LogicalTreeHelper.GetParent (targetControl) is Panel panel)
            {
                var index = panel.Children.IndexOf (targetControl);
                if (index >= 0)
                {
                    panel.Children.RemoveAt (index);

                    var newElement = CreateElement (operation.NewNode);
                    panel.Children.Insert (index, newElement);
                }
            }
            else if (LogicalTreeHelper.GetParent (targetControl) is System.Windows.Controls.ContentControl contentControl)
            {

                if (contentControl.Content == targetControl)
                {
                    var newElement = CreateElement (operation.NewNode);
                    contentControl.Content = newElement;
                }
            }
            else
            {
                throw new InvalidOperationException ($"Unsupported parent type for ReplaceNode: {targetControl.GetType ().Name}");
            }
            targetControl.SetUniqueId (operation.NewNode.Id);
        }
        private static void UpdateProperty(FrameworkElement root, UpdatePropertyOperation operation)
        {
            var targetControl = FindControlById (root, operation.TargetId);

            if (targetControl == null)
            {
                Console.WriteLine ($"Control with ID '{operation.TargetId}' not found.");
                return;
            }

            var property = targetControl.GetType ().GetProperty (
                operation.PropertyName,
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.FlattenHierarchy
            );

            if (property != null && property.CanWrite)
            {
                property.SetValue (targetControl, operation.NewValue);
            }
            else if (operation.PropertyName == "RowDefinitions")
            {
                ((System.Windows.Controls.Grid)targetControl).RowDefinitions.Clear ();

                foreach(var rowdefinition in (List<RowDefinition>)operation.NewValue)
                {
                    ((System.Windows.Controls.Grid)targetControl).RowDefinitions.Add (rowdefinition);
                }
                
            }
            else if(operation.PropertyName == "ColumnDefinitions")
            {
                ((System.Windows.Controls.Grid)targetControl).ColumnDefinitions.Clear ();
                foreach (var columndefinition in (List<ColumnDefinition>)operation.NewValue)
                {
                    ((System.Windows.Controls.Grid)targetControl).ColumnDefinitions.Add (columndefinition);
                }
            }
            else
            {
                if (operation.PropertyName == "Grid.Row")
                {
                    System.Windows.Controls.Grid.SetRow (targetControl, (int)operation.NewValue);
                }
                else if (operation.PropertyName == "Grid.Column")
                {
                    System.Windows.Controls.Grid.SetColumn (targetControl, (int)operation.NewValue);
                }
                else
                {
                    Console.WriteLine ($"Property '{operation.PropertyName}' does not exist or is not writable on '{targetControl.GetType ().Name}'.");
                }
            }
            targetControl.SetUniqueId (operation.NewId);
        }

        private static void AddChild(FrameworkElement root, AddChildOperation operation)
        {
            var targetControl = FindControlById (root, operation.ParentKey);

            if (targetControl == null)
            {
                Console.WriteLine ($"Control with ID '{operation.ParentKey}' not found.");
                return;
            }

            if (targetControl is Panel panel)
            {
                var newElement = CreateElement (operation.ChildNode);
                panel.Children.Add (newElement);
            }
            else
            {
                throw new InvalidOperationException ($"AddChild is only supported for Panel elements, but '{targetControl.GetType ().Name}' was provided.");
            }
        }

        private static void RemoveProperty(FrameworkElement element, RemovePropertyOperation operation)
        {
            var property = element.GetType ().GetProperty (
                operation.PropertyName,
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.FlattenHierarchy
            );

            if (property != null && property.CanWrite)
            {
                var defaultValue = property.PropertyType.IsValueType
                    ? Activator.CreateInstance (property.PropertyType) // 값 형식의 기본값
                    : null; // 참조 형식의 기본값은 null
                property.SetValue (element, defaultValue);
            }
            else
            {
                Console.WriteLine ($"Property '{operation.PropertyName}' does not exist or is not writable on '{element.GetType ().Name}'.");
            }
        }

        private static void RemoveChild(FrameworkElement root, RemoveChildOperation operation)
        {
            var childToRemove = FindControlById (root, operation.TargetId);

            if (childToRemove == null)
            {
                Console.WriteLine ($"Child with ID '{operation.TargetId}' not found.");
                return;
            }

            if (LogicalTreeHelper.GetParent (childToRemove) is Panel panel)
            {
                panel.Children.Remove (childToRemove);
            }
            else
            {
                Console.WriteLine ($"Parent of child with ID '{operation.TargetId}' is not a Panel.");
            }
        }

        public static FrameworkElement CreateElement(IElement node)
        {
            Type elementType = Type.GetType ($"System.Windows.Controls.{node.Type}, PresentationFramework");
            if (elementType == null)
                throw new InvalidOperationException ($"Unknown element type: {node.Type}");

            var element = (FrameworkElement)Activator.CreateInstance (elementType);



            foreach (var property in node.Properties)
            {
                var propInfo = element.GetType ().GetProperty (property.Key);
                if (propInfo != null && propInfo.CanWrite)
                {
                    propInfo.SetValue (element, property.Value);
                }
                else if (property.Key == "Grid.Row")
                {
                    System.Windows.Controls.Grid.SetRow (element, (int)property.Value);
                }
                else if (property.Key == "Grid.Column")
                {
                    System.Windows.Controls.Grid.SetColumn (element, (int)property.Value);
                }
            }

            if (element is Panel panel)
            {
                if(node.Children != null && node.Children.Count > 0)
                {
                    foreach (var childNode in node.Children)
                    {
                        var childElement = CreateElement (childNode);
                        panel.Children.Add (childElement);
                    }
                }
            }

            return element;
        }

        private static FrameworkElement FindControlById(FrameworkElement root, string id)
        {
            if (FrameworkElementExtensions.GetUniqueId (root) == id)
                return root;

            foreach (var child in LogicalTreeHelper.GetChildren (root).OfType<FrameworkElement> ())
            {
                var result = FindControlById (child, id);
                if (result != null)
                    return result;
            }

            return null;
        }
    }
    public static class FrameworkElementExtensions
    {
        private static readonly DependencyProperty UniqueIdProperty =
            DependencyProperty.RegisterAttached (
                "UniqueId",
                typeof (string),
                typeof (FrameworkElementExtensions),
                new PropertyMetadata (null));

        public static void SetUniqueId(this FrameworkElement element, string id)
        {
            element.SetValue (UniqueIdProperty, id);
        }

        public static string GetUniqueId(this FrameworkElement element)
        {
            return (string)element.GetValue (UniqueIdProperty);
        }
    }
}