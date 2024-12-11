using Delta.WPF;

namespace Template.Project.Components
{
    public class CounterComponent : Component
    {
        public override IVisual Render()
        {
            var (count, setCount) = UseState (0);
            var (count2, setCount2) = UseState (0);

            return VStack (
                        Button ($"Count1: {count}", (s, e) => setCount (count + 1)),
                        Button ("Reset1", (s, e) => setCount (0)),
                        Button ($"Count2: {count2}", (s, e) => setCount2 (count2 + 1)),
                        Button ("Reset2", (s, e) => setCount2 (0))
                   );
        }
    }
}
