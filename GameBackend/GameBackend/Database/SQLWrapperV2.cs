using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySqlConsoleApp
{
    abstract class SQLWrapperV2
    {
        // Members
        protected MySqlConnection conn;

        // Functions
        protected abstract void SQLCommands();
        private string readConfig()
        {
            var server = System.Configuration.ConfigurationManager.AppSettings["server"];
            var username = System.Configuration.ConfigurationManager.AppSettings["username"];
            var password = System.Configuration.ConfigurationManager.AppSettings["password"];
            var port = System.Configuration.ConfigurationManager.AppSettings["port"];
            var database= System.Configuration.ConfigurationManager.AppSettings["database"];
            return "server=" + server + ";user=" + username + ";database=" + database + ";port=" + port + ";password=" + password;
        }
        public void execute()
        {
            openConnection();
            SQLCommands();
            closeConnection();
        }

        private void openConnection()
        {
            string connStr = readConfig();
            conn = new MySqlConnection(connStr);
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            Console.WriteLine("Connected.");
        }
        private void closeConnection()
        {
            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
