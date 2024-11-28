using System.Windows;

namespace Delta.WPF
{
    public class DeltaApplication : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow.Show ();
            base.OnStartup (e);
        }
    }
}