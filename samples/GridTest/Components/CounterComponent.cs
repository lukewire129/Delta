﻿using Delta.WPF;
using System.Drawing;

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
            var (check3, setCheck3) = UseState (false);

            return Grid (
                        Rows (Auto, Auto, Auto, Auto, Auto, Auto, Auto),
                            Button ($"count111: {count1}", (s, e) => setCount1 (count1 + 1))
                                .Size (100, 50)
                                .Start ()
                                .Background ("#e8b8FFFF")
                                .Row (0),

                            Button ("count 1 Reset", (s, e) => setCount1 (0))
                                .Margin (bottom: 100)
                                .Row (1),

                            Grid (
                                Rows (50, 100, 100),
                                    Text ($"1 : {count2}")
                                        .FontSize (20)
                                        .FontColor (Color.Red),

                                    Button ($"count 2: {count2}", (s, e) => setCount2 (count2 + 1))
                                        .Size (100, 50)
                                        .Start ()
                                        .Background (Color.Brown)
                                        .FontColor (Color.PeachPuff)
                                        .Row (1),

                                    Button ("count 2 Reset", (s, e) => setCount2 (0))
                                        .Row (2)
                            )
                            .Row (2),

                           //!check3 ? new CounterComponent1 ().Row (3) :
                           //          new CounterComponent2 ().Row (3),

                            Grid (
                                Rows (Auto, Auto),
                                     Text ($"TextChanged : {text}")
                                        .FontSize (20)
                                        .FontColor (Color.Red)
                                        .Row (0),

                                     Input ()
                                         .OnTextChanged (s => setText (s))
                                         .FontColor (Color.Blue)
                                         .Size (100, 50)
                                         .Row (1)
                                )
                                .Row (4),

                             Grid (
                                 Rows (Auto, Auto),
                                     Text ($"CheckBox : {check}")
                                         .FontSize (20)
                                         .FontColor (Color.Red)
                                         .Row (0),

                                     Check ()
                                         .OnCheckChanged (s => setCheck(s))
                                         .FontColor (Color.Blue)
                                         .Size (100, 50)
                                         .Row (1)
                                )
                                .Row (5),
                            HStack (
                                    VStack (
                                        Radio ($"RadioButton 1 : {check1}")
                                            .OnCheckChanged ((s) => setCheck1 (s))
                                            .FontColor (Color.Blue)
                                            .FontSize (10),

                                        Radio ($"RadioButton 2 : {check3}")
                                            .OnCheckChanged ((s) => setCheck3 (s))
                                            .FontSize (10)
                                            .FontColor (Color.Blue)
                                    )
                               )
                               .Row (6)
                    );
        }
    }
}