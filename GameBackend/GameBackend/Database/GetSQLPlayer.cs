using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using GameBackend.Models;

namespace GameBackend.Database
{
    public class GetSQLPlayer : SQLWrapper
    {
        public PlayerData playerData { get; set; }
        protected override void SQLCommands()
        {
            string sql = "SELECT first_name, HeadOfState FROM Country WHERE Continent='North America'";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + "\t" + rdr[1]);
            }
            rdr.Close();
        }
    }
}