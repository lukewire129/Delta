using System.Windows;

namespace Delta.WPF
{
    public class DeltaApplication : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup (e);
            var mainWindow = new MainWindow ();
            MainWindow.Show ();
        }
    }
}