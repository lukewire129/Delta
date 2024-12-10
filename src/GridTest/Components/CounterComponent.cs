using Delta.WPF;
using System.Drawing;

namespace GridTest.Components
{
    public class CounterComponent : Component
    {
        public override IVisual Render()
        {
            var (count1, setCount1) = UseState (0);
            var (count2, setCount2) = UseState (0);

            return Grid (
                        Rows (Auto, Auto, Auto, Auto),
                        Button ($"count 1: {count1}", (s, e) => setCount1 (count1 + 1))
                            .Size(100, 50)
                            .Start()
                            .Background("#e8b8FFFF")
                            .Row(0),
                        Button ("count 1 Reset", (s, e) => setCount1 (0))
                            .Margin(bottom: 100)
                            .Row (1),

                        Grid (
                            Rows (50 ,100, 100),
                            Text($"hihi : {count2}")
                                .FontSize(20)
                                .FontColor(Color.Red),

                            Button ($"count 2: {count2}", (s, e) => setCount2 (count2 + 1))
                                .Size (100, 50)
                                .Start ()
                                .Background(Color.Brown)
                                .FontColor(Color.PeachPuff)
                                .Row (1),

                             Button ("count 2 Reset", (s, e) => setCount2 (0))
                                .Row (2)
                        )
                        .Row(2),
                    
                        new CounterComponent1 ()
                            .Row (3)
                    );
        }
    }
}