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

            var counterComponent = new CounterComponent ();
            Content = counterComponent; // CounterComponent is its own root panel.
        }
    }
}