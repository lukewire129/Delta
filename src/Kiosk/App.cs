using Delta.WPF;
using System.Windows;

namespace Kiosk
{
    public class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup (e);

            var mainWindow = new MainWindow ();
            mainWindow.Show ();
        }
    }
}