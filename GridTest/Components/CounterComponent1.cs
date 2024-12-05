using Delta.WPF;

namespace GridTest.Components
{
    public class CounterComponent1 : Component
    {
        public override IVisual Render()
        {
            var (count, setCount) = UseState (0);

            return Grid (
                        Button ($"Count: {count}", (s, e) => setCount (count + 1))
                            .Size (100, 50)
                            .Start ()
                            .Row (0),

                        Button ("Reset", (s, e) => setCount (0))
                            .Row (1)
                    )
                    .Rows (100, 100);
        }
    }

    public partial class Control
    {
        public static IElement CounterComponent1()
        {
            return new CounterComponent1 ();
        }
    }
}
