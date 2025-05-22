namespace DDO_Launcher
{
    internal static class Program
    {
        private static readonly string SERVERS_FILE = "DDO_Launcher.ini";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new launcherPrincipal(new ServerManager(SERVERS_FILE)));
        }
    }
}