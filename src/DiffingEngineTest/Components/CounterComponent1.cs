using Delta.WPF;

namespace DiffingEngineTest.Components
{
    public class CounterComponent1 : Component
    {
        public override IVisual Render()
        {
            var (count, setCount) = UseState (0);

            return Grid (
                        Rows (100, 100),
                        Button ($"Comopent Count!: {count}", (s, e) => setCount (count + 1))
                            .Size (150, 50)
                            .Start ()
                            .Row (0),

                        Button ("Comopent Count Reset", (s, e) => setCount (0))
                            .Row (1)
                    );
        }
    }
}
