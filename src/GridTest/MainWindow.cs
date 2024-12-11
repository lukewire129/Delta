using Delta.WPF;
using GridTest.Components;
using System.Windows;
using System.Windows.Threading;

namespace GridTest
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            Title = "MVU Application";
            Width = 400;
            Height = 1000;

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