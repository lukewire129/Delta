using Delta.WPF;
using DeltaWPFSample.Components.MainLayout;
using System.Windows;

namespace DeltaWPFSample
{
    public class App : Application
    {
        public App()
        {
            MainWindow = new MainWindow ();

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow.Show ();
            base.OnStartup (e);
        }
    }
}
