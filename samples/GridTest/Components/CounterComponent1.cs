using Delta.WPF;

namespace GridTest.Components
{
    public class CounterComponent1 : Component
    {
        public CounterComponent1()
        {
            
        }
        public override IVisual Render()
        {
            var (count, setCount) = UseState (0);

            return Grid (
                        Rows (100, 100),
                        Button ($"Comopent1 Count!: {count}", (s, e) => setCount (count + 1))
                            .Size (150, 50)
                            .Start ()
                            .Row (0),

                        Button ("Comopent1 Count Reset", (s, e) => setCount (0))
                            .Row (1)
                    );
        }
    }

    // TODO : 제네레이터 만들어주는 기능 필요할까?
}