using Delta.WPF;
using System.Drawing;
using Base = System.Windows.Controls;

namespace BorderTest.Components
{
    public class CounterComponent : Component
    {
        public override IVisual Render()
        {
            var (count, setCount) = UseState (0);
            var (count2, setCount2) = UseState (0);

            //return Border (
            //            Grid (
            //                Text ("hihi")
            //                )
            //                .Background (Color.Blue)
            //       )
            //      .CornerRadius (20)
            //      .Background (Color.Red)
            //      .Brush (Color.Black);
            return Border (
                        Path("M 0,0 L 103,0 L 118,14 L 103,28 L 0,28 C 10,14 0,0 0,0 Z")
                            .Brush(Color.Black)
                            .Center()
                   )
                  .CornerRadius (20)
                  .Background (Color.Red)
                  .Brush (Color.Black);
        }
    }
}
