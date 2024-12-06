using Delta.WPF;

namespace GridTest.Components
{
    public class CounterComponent : Component
    {
        public override IVisual Render()
        {
            var (count, setCount) = UseState (0);
            var (count1, setCount1) = UseState (0);


            return Grid (
                        Button ($"Count123: {count}", (s, e) => setCount (count + 1))
                            .Size(100, 50)
                            .Start()
                            .Row(0),

                        Button ("Reset123", (s, e) => setCount (0))
                            .Row (1),

                        Grid(
                             Button ($"Count123: {count1}", (s, e) => setCount1 (count1 + 1))
                                .Size (100, 50)
                                .Start ()
                                .Row (0),

                             Button ("Reset123", (s, e) => setCount1 (0))
                                .Row (1)
                        )
                        .Rows (100, 100)
                        .Row(2),
                    
                        new CounterComponent1 ()
                            .Row (3)
                    )
                    .Rows (100, 100, 200,200);
        }
    }
}
