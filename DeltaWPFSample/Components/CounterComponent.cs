using Delta.WPF;
using Delta.WPF.cc;
using System.Windows.Controls;

namespace DeltaWPFSample.Components
{
    public class CounterComponent : HookComponent
    {
        public override VisualNode Render()
        {
            var (count, setCount) = UseState (0);

            return new DeltaVStack ()
                .AddChild (new DeltaButton ($"Count: {count}", () => setCount (count + 1)))
                .AddChild (new DeltaButton ("Reset", () => setCount (0)));
        }
    }

}
