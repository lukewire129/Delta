using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace Delta.WPF
{
    public static class MarkupBuilder
    {
        public static FrameworkElement Build(IElement node)
        {
            Type elementType;            
            elementType = Type.GetType ($"System.Windows.Controls.{node.Type}, PresentationFramework");
            if (elementType == null)
            {
                elementType = Type.GetType ($"System.Windows.Shapes.{node.Type}, PresentationFramework");
                if (elementType == null)
                    throw new InvalidOperationException ($"Unknown element type: {node.Type}");
            }

            var element = (FrameworkElement)Activator.CreateInstance (elementType);
            element.SetUniqueId (node.Id); // 고유 ID 설정
            // Grid-specific setup for RowDefinitions and ColumnDefinitions
            if (element is System.Windows.Controls.Grid grid)
            {
                // Add RowDefinitions
                if (node.TryGetValue ("RowDefinitions", out var rowDefs) && rowDefs is List<RowDefinition> rows)
                {
                    foreach (var row in rows)
                    {
                        grid.RowDefinitions.Add (row);
                    }
                }

                // Add ColumnDefinitions
                if (node.TryGetValue ("ColumnDefinitions", out var colDefs) && colDefs is List<ColumnDefinition> cols)
                {
                    foreach (var col in cols)
                    {
                        grid.ColumnDefinitions.Add (col);
                    }
                }
            }

            // 속성 설정
            foreach (var property in node.Properties)
            {
                var propInfo = element.GetType ().GetProperty (property.Key);
                if (propInfo != null && propInfo.CanWrite)
                {
                    propInfo.SetValue (element, property.Value);
                }
            }

            // Bind events
            foreach (var evt in node.Events)
            {
                var eventInfo = element.GetType ().GetEvent (evt.Key);
                if (eventInfo != null)
                {
                    eventInfo.AddEventHandler (element, evt.Value);
                }
            }

            //// Bind Animations
            //foreach (var evt in node.Animations)
            //{
            //    var dependencyProperty = AnimationMapper.GetDependencyProperty (evt.Key);

            //    if (dependencyProperty != null)
            //    {
            //        // Rotate 처리: RenderTransform이 설정되어 있는지 확인
            //        if (evt.Key == "Rotate")
            //        {
            //            if (!(element.RenderTransform is RotateTransform rotateTransform))
            //            {
            //                rotateTransform = new RotateTransform ();
            //                element.RenderTransform = rotateTransform;

            //                // 중심 축을 설정 (기본적으로 중심을 기준으로 회전)
            //                element.RenderTransformOrigin = new Point (0.5, 0.5);
            //            }

            //            // RotateTransform의 애니메이션 설정
            //            rotateTransform.BeginAnimation (RotateTransform.AngleProperty, evt.Value);
            //        }
            //        else
            //        {
            //            // 일반 속성의 애니메이션 설정
            //            element.BeginAnimation (dependencyProperty, evt.Value);
            //        }
            //    }
            //}

            // Process children and Grid.Row/Grid.Column properties // Component인 경우엔 Grid로
            if (node.Children.Count > 0)
            {
                if (element is System.Windows.Controls.Panel panel)
                {
                    foreach (var childNode in node.Children)
                    {
                        var childElement = Build (childNode);

                        // Apply Grid.Row and Grid.ColumnSystem.NullReferenceException: 'Object reference not set to an instance of an object.'
                        var attachedProperty = childNode.GetAttachedProperty ();
                        foreach (var item in attachedProperty)
                        {
                            childElement.UpdateAttachedProperty (item.Key, item.Value);
                        }

                        panel.Children.Add (childElement);
                    }
                }
                else if (element is System.Windows.Controls.ContentControl contentControl)
                {
                    foreach (var childNode in node.Children)
                    {
                        var childElement = Build (childNode);

                        // Apply Grid.Row and Grid.ColumnSystem.NullReferenceException: 'Object reference not set to an instance of an object.'
                        var attachedProperty = childNode.GetAttachedProperty ();
                        foreach (var item in attachedProperty)
                        {
                            childElement.UpdateAttachedProperty (item.Key, item.Value);
                        }

                        contentControl.Content = childElement;
                    }
                }
                else if (element is System.Windows.Controls.Border borderControl)
                {
                    foreach (var childNode in node.Children)
                    {
                        var childElement = Build (childNode);

                        // Apply Grid.Row and Grid.ColumnSystem.NullReferenceException: 'Object reference not set to an instance of an object.'
                        var attachedProperty = childNode.GetAttachedProperty ();
                        foreach (var item in attachedProperty)
                        {
                            childElement.UpdateAttachedProperty (item.Key, item.Value);
                        }

                        borderControl.Child = childElement;
                    }
                }
            }

            return element;
        }
    }
}
