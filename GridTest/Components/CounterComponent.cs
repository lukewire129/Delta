using Delta.WPF;

namespace GridTest.Components
{
    public class CounterComponent : Component
    {
        public override IVisual Render()
        {
            var (count, setCount) = UseState (0);


            return Grid (
                        Button ($"Count123: {count}", (s, e) => setCount (count + 1))
                            .Size(100, 50)
                            .Start()
                            .Row(0),

                        Button ("Reset123", (s, e) => setCount (0))
                            .Row (1),

                      new CounterComponent1 ()
                            .Row (2)
                    )
                    .Rows (100, 100, 300);
        }
    }
}
