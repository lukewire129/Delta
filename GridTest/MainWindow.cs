using Delta.WPF;
using GridTest.Components;
using System.Windows;

namespace GridTest
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            Title = "MVU Application";
            Width = 400;
            Height = 300;

            ApplicationRoot.Initialize (new CounterComponent (), this);
        }
    }
}