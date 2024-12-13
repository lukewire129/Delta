using Delta.WPF;
using System.Drawing;

namespace ContentControlChildrenTest.Components
{
    public class CounterComponent : Component
    {
        public override IVisual Render()
        {
            var (count, setCount) = UseState (0);

            return Grid (
                     Border ()
                        .Background ("#00070E")
                        .Brush ("#34291E")
                        .Margin (left: 10),
                     Img($"Resources/logo.png")
                        .Start()
                        .Height(38)
                        .SetProperty("RenderOptions.BitmapScalingMode", System.Windows.Media.BitmapScalingMode.Fant),

                     Border ()
                        .Background ("#1E2328")
                        .Brush ("#09343D")
                        .Thickness (2)
                        .Margin (50, 4, 4, 4),

                     Path ("M 0,0 L 103,0 L 118,14 L 103,28 L 0,28 C 10,14 0,0 0,0 Z")
                        .Fill("#1E2328")
                        .Brush (LinearGradient ("0.5,0", "0.5,1")
                                    .AddGradientStop("#CC3FE7FF", 0)
                                    .AddGradientStop ("#CC006D7D", 0.5)
                                    .AddGradientStop ("#CC0493A7", 1))
                        .Thickness(2)
                        .Margin (40, 5, 4, -5)
                        .DropShadowEffect(BlurRadius:5, Depth:2)
                   )
                   .Size (165, 39)
                   .Background (Color.Transparent);
        }
    }
}
