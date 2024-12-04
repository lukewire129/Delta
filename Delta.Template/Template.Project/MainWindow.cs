using Delta.WPF;
using DeltaTemplate.Components;
using System.Windows;

namespace DeltaTemplate
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