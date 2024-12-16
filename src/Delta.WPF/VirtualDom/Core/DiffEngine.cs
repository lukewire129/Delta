using Delta.WPF.VirtualDom.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace Delta.WPF
{
    public static partial class DiffEngine
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
                foreach (var oldAnimation in oldNode.Animations)
                {
                    // 기존 핸들러 제거
                    operations.Add (new RemoveAnimationOperation (oldNode, oldAnimation));
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

                foreach (var oldEvent in oldNode.Animations)
                {
                    if (!newNode.Animations.ContainsKey (oldEvent.Key) ||
                        newNode.Animations[oldEvent.Key] != oldEvent.Value)
                    {
                        // 기존 핸들러 제거
                        operations.Add (new RemoveAnimationOperation (oldNode, oldEvent));
                    }
                }


                foreach (var newEvent in newNode.Animations)
                {
                    if(oldNode.Properties[newEvent.Key].ToString() == newNode.Properties[newEvent.Key].ToString ())
                    {
                        continue;
                    }
                    if (!oldNode.Animations.ContainsKey (newEvent.Key) ||
                        oldNode.Animations[newEvent.Key] != newEvent.Value)
                    {
                        var temp = newEvent.Value.GetType ();
                        if(temp.Name == nameof(DoubleAnimation))
                        {
                            var ani = (DoubleAnimation)newEvent.Value;
                            ani.From = (double)oldNode.Properties[newEvent.Key];
                        }
                        if (temp.Name == nameof (ThicknessAnimation))
                        {
                            var ani = (ThicknessAnimation)newEvent.Value;
                            ani.From = (Thickness)oldNode.Properties[newEvent.Key];
                        }
                        if (temp.Name == nameof (ColorAnimation))
                        {
                            var ani = (ColorAnimation)newEvent.Value;
                            ani.From = (Color)oldNode.Properties[newEvent.Key];
                        }
                        // 새로운 핸들러 추가
                        operations.Add (new AddAnimationOperation (oldNode, newEvent));
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

                if (oldValue.GetType () != property.Value.GetType ())
                {
                    operations.Add (new UpdatePropertyOperation (oldNode.Id, newNode.Id, property.Key, property.Value));
                    continue;
                }

                if (oldValue.GetType ().BaseType.Name == "Brush")
                {
                    if (oldValue.GetType ().Name == "SolidColorBrush")
                    {
                        if (AreBrushesEqual ((System.Windows.Media.SolidColorBrush)oldValue, (System.Windows.Media.SolidColorBrush)property.Value) == false)
                        {
                            operations.Add (new UpdatePropertyOperation (oldNode.Id, newNode.Id, property.Key, property.Value));
                        }
                    }
                    continue;
                }
                if(oldValue.GetType ().BaseType.Name == "GradientBrush")
                {
                    if (AreLinearGradientBrushesEqual ((System.Windows.Media.LinearGradientBrush)oldValue, (System.Windows.Media.LinearGradientBrush)property.Value) == false)
                    {
                        operations.Add (new UpdatePropertyOperation (oldNode.Id, newNode.Id, property.Key, property.Value));
                    }
                    continue;
                }
                if(oldValue.GetType().Name == "BitmapImage")
                {
                    if(AreBitmapImagesEqual((BitmapImage)oldValue, (BitmapImage)property.Value) == false)
                    {
                        operations.Add (new UpdatePropertyOperation (oldNode.Id, newNode.Id, property.Key, property.Value));
                    }
                    continue;
                }
                if(oldValue.GetType().Name == "StreamGeometry")
                {
                   if(oldValue.ToString() != property.Value.ToString())
                    {
                        operations.Add (new UpdatePropertyOperation (oldNode.Id, newNode.Id, property.Key, property.Value));
                    }
                    continue;
                }
                if(oldValue.GetType().Name== "DropShadowEffect")
                {
                    if(CompareDropShadowEffects((DropShadowEffect)oldValue, (DropShadowEffect)property.Value) == false)
                    {
                         operations.Add (new UpdatePropertyOperation (oldNode.Id, newNode.Id, property.Key, property.Value));
                    }
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
        private static bool AreBrushesEqual(SolidColorBrush brushA, SolidColorBrush brushB)
        {
            if (brushA == null || brushB == null)
                return false;

            return brushA.Color == brushB.Color && brushA.Opacity == brushB.Opacity;
        }

        private static bool AreGradientBrushesEqual(GradientBrush brushA, GradientBrush brushB)
        {
            if (brushA == null || brushB == null)
                return false;

            return brushA.GradientStops.Count == brushB.GradientStops.Count &&
                   brushA.ColorInterpolationMode == brushB.ColorInterpolationMode &&
                   brushA.MappingMode == brushB.MappingMode &&
                   brushA.SpreadMethod == brushB.SpreadMethod;
        }

        private static bool AreLinearGradientBrushesEqual(LinearGradientBrush brushA, LinearGradientBrush brushB)
        {
            if(!AreGradientBrushesEqual(brushA, brushB))
            {
                return false;
            }

            return brushA.StartPoint == brushB.StartPoint &&
                   brushA.EndPoint == brushB.EndPoint;
        }
        private static bool AreBitmapImagesEqual(BitmapImage img1, BitmapImage img2)
        {
            if (img1 == null || img2 == null)
                return false;

            // BitmapSource로 변환
            var bitmap1 = new FormatConvertedBitmap (img1, PixelFormats.Bgra32, null, 0);
            var bitmap2 = new FormatConvertedBitmap (img2, PixelFormats.Bgra32, null, 0);

            // 크기 비교
            if (bitmap1.PixelWidth != bitmap2.PixelWidth || bitmap1.PixelHeight != bitmap2.PixelHeight)
                return false;

            // 픽셀 데이터 가져오기
            var buffer1 = new byte[bitmap1.PixelWidth * bitmap1.PixelHeight * 4];
            var buffer2 = new byte[bitmap2.PixelWidth * bitmap2.PixelHeight * 4];

            bitmap1.CopyPixels (buffer1, bitmap1.PixelWidth * 4, 0);
            bitmap2.CopyPixels (buffer2, bitmap2.PixelWidth * 4, 0);

            // 바이트 배열 비교
            return buffer1.SequenceEqual (buffer2);
        }
        private static bool CompareDropShadowEffects(DropShadowEffect effect1, DropShadowEffect effect2)
        {
            if (effect1 == null || effect2 == null)
                return false;

            return effect1.Color == effect2.Color &&
                   effect1.BlurRadius == effect2.BlurRadius &&
                   effect1.ShadowDepth == effect2.ShadowDepth &&
                   effect1.Direction == effect2.Direction &&
                   effect1.Opacity == effect2.Opacity &&
                   effect1.RenderingBias == effect2.RenderingBias;
        }
    }
}
