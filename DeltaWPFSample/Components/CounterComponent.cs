using Delta.WPF;
using static Delta.WPF.DeltaControl;

namespace DeltaWPFSample.Components
{
    public class CounterComponent : HookComponent
    {
        public override VisualNode Render()
        {
            var (count, setCount) = UseState (0);
            return VStack (
                        Button ($"Count: {count}", () => setCount (count + 1)),
                        Button ("Reset", () => setCount (0))
                   );
        }
    }
}
