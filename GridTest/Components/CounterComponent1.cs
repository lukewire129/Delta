using Delta.WPF;

namespace GridTest.Components
{
    public class CounterComponent1 : HookComponent
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

    public partial class Control : VisualNode
    {
        public static IVisual CounterComponent1()
        {
            var counterComponent1 = ApplicationRoot.GetOrCreateComponent (new CounterComponent1 ());
            return counterComponent1.Render ();
        }
    }
}
