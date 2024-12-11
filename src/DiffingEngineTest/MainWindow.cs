using Delta.WPF;
using DiffingEngineTest.Components;
using System.Windows;

namespace DiffingEngineTest
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            Title = "MVU Application";
            Width = 800;
            Height = 600;
            HotReloadService.UpdateApplicationEvent += ReloadUI;
            ApplicationRoot.Initialize (new CounterComponent (), this);
        }

        private void ReloadUI(Type[] obj)
        {
            Dispatcher.BeginInvoke (() =>
            {
                ApplicationRoot.Instance.Rebuild ();
            });
        }
    }
}