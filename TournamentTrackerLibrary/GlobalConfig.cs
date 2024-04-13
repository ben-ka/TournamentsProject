using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentTrackerLibrary.DataAccess;
using TournamentTrackerLibrary.Models;
using System.Configuration;

namespace TournamentTrackerLibrary
{
    public static class GlobalConfig
    {
        /// <summary>
        /// represents the connection of the program. Currently there can only be one connection
        /// </summary>
        public static IDataConnection connection { get; private set; }
       

        public static void InitializeConnection(DatabaseType db)
        {

            switch (db)
            {
                case DatabaseType.Sql:
                    SQLConnector sqlConnect = new SQLConnector();
                    connection = sqlConnect;
                    break;

                case DatabaseType.TextFile:
                    TextConnector textConnect = new TextConnector();
                    connection = textConnect;
                    break;

                default:
                    break;
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
