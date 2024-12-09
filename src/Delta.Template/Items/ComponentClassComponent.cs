using Delta.WPF;

namespace DeltaComponentReplace;

public class ComponentClassComponent : HookComponent
{
    public override IVisual Render()
    {
        var (count, setCount) = UseState (0);


        return Grid (
                    Button ($"Count: {count}", (s, e) => setCount (count + 1))
                        .Size(100, 50)
                        .Start()
                        .Row(0),

                    Button ("Reset", (s, e) => setCount (0))
                        .Row (1)
                )
                .Rows (100, 100, 300);
    }
}