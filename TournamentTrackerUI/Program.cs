using TournamentTrackerLibrary;
using TournamentTrackerLibrary.Models;
namespace TournamentTrackerUI
{

    public static class Program
    {
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the database connection
            GlobalConfig.InitializeConnection(DatabaseType.TextFile);

            //Application.Run(new TournamentDashboardForm());
            Application.Run(new CreateTournamentForm());
        }
    }
}