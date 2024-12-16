using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Delta.WPF
{
    public class AnimationMapper
    {
       public static readonly Dictionary<string, Func<int, object, EasingFunctionBase, AnimationTimeline>> factory =
       new Dictionary<string, Func<int, object, EasingFunctionBase, AnimationTimeline>>
       {
            { "Opacity", (duration,  to, easing) => new DoubleAnimation
                {
                    To = (double)to,
                    Duration = TimeSpan.FromMilliseconds(duration),
                    EasingFunction = easing
                }
            },
            { "Margin", (duration,  to, easing) => new ThicknessAnimation
                {
                    To = (Thickness)to,
                    Duration = TimeSpan.FromMilliseconds(duration),
                    EasingFunction = easing
                }
            },
            { "Background", (duration, to, easing) => new ColorAnimation
                {
                    To = (Color)to,
                    Duration = TimeSpan.FromMilliseconds(duration),
                    EasingFunction = easing
                }
            },
            { "Foreground", (duration, to, easing) => new ColorAnimation
                {
                    To = (Color)to,
                    Duration = TimeSpan.FromMilliseconds(duration),
                    EasingFunction = easing
                }
            },
            { "Rotate", (duration, to, easing) => new DoubleAnimation
                {
                    To = (double)to,
                    Duration = TimeSpan.FromMilliseconds(duration),
                    EasingFunction = easing
                }
            }
       };

        public static DependencyProperty GetDependencyProperty(string property)
        {
            return property switch
            {
                "Opacity" => UIElement.OpacityProperty,
                "Margin" => FrameworkElement.MarginProperty,
                "Background" => Control.BackgroundProperty,
                "Foreground" => Control.ForegroundProperty,
                "Rotate" => RotateTransform.AngleProperty, 
                _ => null
            };
        }
    }
}
