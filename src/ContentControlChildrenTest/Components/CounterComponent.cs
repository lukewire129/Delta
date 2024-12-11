using Delta.WPF;

namespace ContentControlChildrenTest.Components
{
    public class CounterComponent : Component
    {
        public override IVisual Render()
        {
            var (count, setCount) = UseState (0);
            var (count2, setCount2) = UseState (0);

            return VStack (
                        Button (
                            Grid(
                                Radio()
                            ), (s, e) => setCount (count + 1))
                   );
        }
    }
}
