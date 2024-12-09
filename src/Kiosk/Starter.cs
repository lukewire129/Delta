namespace Kiosk
{
    public class Starter
    {
        [STAThread]
        private static void Main(string[] args)
        {
            _ = new App ()
                .Run ();
        }
    }
}
