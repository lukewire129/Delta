using Delta.WPF;
using DeltaWPFSample.Components;
using System.Windows;

namespace DeltaWPFSample
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