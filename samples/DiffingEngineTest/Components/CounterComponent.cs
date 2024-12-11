using Delta.WPF;

namespace DiffingEngineTest.Components
{
    public class CounterComponent : Component
    {
        public override IVisual Render()
        {
            var (visible, setVisible) = UseState (true);

            return VStack (
                        Button ($"Count1: {visible}", (s, e) => setVisible (!visible)),
                        visible? new CounterComponent1 () : null
                   );
        }
    }
}
