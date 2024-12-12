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

            return Border(
                        Grid(
                            Text("hihi")
                            )
                            .Background(Color.Blue)
                   )
                  .CornerRadius(20)
                  .Background(Color.Red)
                  .Brush(Color.Black);
        }
    }
}
