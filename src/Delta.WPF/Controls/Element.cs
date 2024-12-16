using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Media.Animation;

namespace Delta.WPF
{
    public class Element : FrameworkElement, IElement
    {
        public string ParentId { get; set; } = "0";
        public string Id { get; set; } = "0";
        public string Type { get; set; }
        public string Name { get; set; } = "";
        public List<IElement> Children { get; set; } = new List<IElement>();
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object> ();

        public Dictionary<string, Delegate> Events { get; set; } = new Dictionary<string, Delegate> (); // 이벤트 저장
        public Dictionary<string, AnimationTimeline> Animations { get; set; } = new Dictionary<string, AnimationTimeline> (); // 애니메이션 저장

        public bool TryGetValue(string propertyName, [MaybeNullWhen (false)] out object value)
        {
            if (Properties.TryGetValue (propertyName, out var temp))
            {
                value = temp;
                return true;
            }

            value = default;
            return false;
        }

        public void LoadNodeNumber(string parentId, int myId)
        {
            ParentId = parentId;
            this.Id = $"{parentId}_{myId}";
        }
        public IElement SetProperty(string name, object value)
        {
            Properties[name] = value;
            return this;
        }

        public IElement AddEvent(string eventName, Delegate handler)
        {
            Events[eventName] = handler;
            return this;
        }
        public IElement AddAnimation(string animationName, AnimationTimeline timeline)
        {
            Animations[animationName] = timeline;
            return this;
        }

        public new bool Equals(object obj)
        {
            if (!(obj is Element other))
                return false;

            return Type == other.Type;
        }
    }

    public static partial class ElementVisualExtention
    {
        public static T Transitions<T>(this T node, string property, int msec, Easing easing) where T : IElement
        {
            if (AnimationMapper.factory.TryGetValue (property, out var createAnimation))
            {
                int Easingtype = (int)easing / 2;
                int EasingValue = (int)easing % 2;  // 2 : InOut, 1 : Out, 0 : In
                EasingFunctionBase Funcitionbase = null;
                if (Easingtype == 0)
                {
                    Funcitionbase = new CubicEase ()
                    {
                        EasingMode = GetType(EasingValue),
                    };
                }

                return node.Transitions (property, msec, Funcitionbase);
            }
            else
            {
                throw new NotSupportedException ($"Property '{property}' is not supported for animation.");
            }
        }
        public static T Transitions<T>(this T node, string property, int msec, EasingFunctionBase easingFunction = null) where T : IElement
        {
            if (AnimationMapper.factory.TryGetValue (property, out var createAnimation))
            {
                var animation = createAnimation (msec, node.Properties[property],  easingFunction);
                node.AddAnimation (property, animation);
            }
            else
            {
                throw new NotSupportedException ($"Property '{property}' is not supported for animation.");
            }
            return node;
        }

        private static EasingMode GetType(int value)
        {
            return value switch
            {
                0 => EasingMode.EaseIn,
                1 => EasingMode.EaseOut,
                2 => EasingMode.EaseInOut,
            };
        }
    }
}
