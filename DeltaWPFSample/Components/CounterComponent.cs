using Delta.WPF;
using static Delta.WPF.Control;

namespace DeltaWPFSample.Components
{
    public class CounterComponent : HookComponent
    {
        public override IVisual Render()
        {
            var (count, setCount) = UseState (0);
            return VStack (
                        Button ($"Count: {count}", (s, e) => setCount (count + 1)),
                        Button ("Reset", (s, e) => setCount (0))
                   );
        }
    }
}
