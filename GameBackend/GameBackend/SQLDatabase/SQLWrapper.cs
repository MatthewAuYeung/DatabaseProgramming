using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using GameBackend.Models;

namespace GameBackend.SQLDatabase
{
    public abstract class SQLWrapper
    {
        // Members
        public PlayerData playerData;
        public MatchData matchData;
        public IList<MatchData> matchDatas;
        public string start_date;
        public string end_date;

        protected MySqlConnection conn;

        // Functions
        protected abstract void SQLCommands();
        private string readConfig()
        {
            var server = "localhost"; //System.Configuration.ConfigurationManager.AppSettings["server"];
            var username = "root"; //System.Configuration.ConfigurationManager.AppSettings["username"];
            var password = "password"; //System.Configuration.ConfigurationManager.AppSettings["password"];
            var port = "3306"; //System.Configuration.ConfigurationManager.AppSettings["port"];
            var database = "final"; //System.Configuration.ConfigurationManager.AppSettings["database"];
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