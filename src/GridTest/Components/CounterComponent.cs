using Delta.WPF;

namespace GridTest.Components
{
    public class CounterComponent : Component
    {
        public override IVisual Render()
        {
            var (count1, setCount1) = UseState (0);
            var (count2, setCount2) = UseState (0);


            return Grid (
                        Button ($"count 1: {count1}", (s, e) => setCount1 (count1 + 1))
                            .Size(100, 50)
                            .Start()
                            .Row(0),

                        Button ("count 1 Reset", (s, e) => setCount1 (0))
                            .Row (1),

                        Grid(
                             Button ($"count 2: {count2}", (s, e) => setCount2 (count2 + 1))
                                .Size (100, 50)
                                .Start ()
                                .Row (0),

                             Button ("count 2 Reset", (s, e) => setCount2 (0))
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