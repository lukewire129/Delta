using ContentControlChildrenTest.Components;
using Delta.WPF;
using System.Windows;

namespace ContentControlChildrenTest
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