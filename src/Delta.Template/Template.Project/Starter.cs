﻿namespace Template.Project
{
    public class Starter
    {
        [STAThread]
        private static void Main(string[] args)
        {
            new App ()
                .Run (new MainWindow ());
        }
    }
}
