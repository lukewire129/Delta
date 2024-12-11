using Delta.WPF;

namespace ContentControlChildrenTest.Components
{
    public class CounterComponent : Component
    {
        public override IVisual Render()
        {
            var (count, setCount) = UseState (0);

            return VStack (
                        Button (
                            Grid(
                                Radio($"count Number {count}")
                            ), (s, e) => setCount (count + 1))
                   );
        }
    }
}
