using Delta.WPF;
using System.Drawing;
using System.Windows.Controls;

namespace GridTest.Components
{
    public class CounterComponent : Component
    {
        public override IVisual Render()
        {
            var (count1, setCount1) = UseState (0);
            var (count2, setCount2) = UseState (0);

            var (text, setText) = UseState ("");
            var (check, setCheck) = UseState (false);
            var (check1, setCheck1) = UseState (true);
            var (check2, setCheck2) = UseState (false);

            return Grid (
                        Rows (Auto, Auto, Auto, Auto, Auto, Auto, Auto),
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
                                .Row (3),

                           Grid(
                               Rows(Auto, Auto),
                                     Text ($"TextChanged : {text}")
                                            .FontSize (20)
                                            .FontColor (Color.Red)
                                            .Row (0),

                                    Input()
                                        .OnTextChanged ((s, e) =>
                                        {
                                            if (s is TextBox textBox)
                                            {
                                                setText (textBox.Text);
                                                //Console.WriteLine (textBox.Text);
                                            }
                                        })
                                        .FontColor(Color.Blue)
                                        .Size(100, 50)
                                        .Row(1)
                               )
                               .Row(4),

                            Grid (
                                Rows (Auto, Auto),
                                    Text ($"CheckBox : {check}")
                                        .FontSize (20)
                                        .FontColor (Color.Red)
                                        .Row (0),

                                    Check ()
                                        .OnChanged ((s, e) =>
                                        {
                                            if (s is CheckBox checkBox)
                                            {
                                                setCheck (checkBox.IsChecked.Value);
                                            }
                                        })
                                        .FontColor (Color.Blue)
                                        .Size (100, 50)
                                        .Row (1)
                               )
                               .Row (5),
                            HStack(
                                    VStack(
                                         Text ($"RadioButton 1 : {check1}")
                                            .FontSize (20)
                                            .FontColor (Color.Red),

                                         Text ($"RadioButton 2 : {check2}")
                                            .FontSize (20)
                                            .FontColor (Color.Red)
                                      
                                    ),

                                    VStack (
                                        Radio ()
                                        .OnChanged ((s, e) =>
                                        {
                                            if (s is RadioButton radio)
                                            {
                                                setCheck1 (radio.IsChecked.Value);
                                            }
                                        })
                                        .FontColor (Color.Blue)
                                        .Size (100, 50),

                                        Radio ()
                                        .OnChanged ((s, e) =>
                                        {
                                            if (s is RadioButton radio)
                                            {
                                                setCheck2 (radio.IsChecked.Value);
                                            }
                                        })
                                        .FontColor (Color.Blue)
                                        .Size (100, 50)
                                    )
                               )
                               .Row (6)
                    );
        }
    }
}