using Delta.WPF;
using Kiosk.Components;
using System.Windows;

namespace Kiosk
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            Title = "MVU Application";
            Width = 800;
            Height = 600;

            ApplicationRoot.Initialize (new CounterComponent (), this);
        }
    }
}