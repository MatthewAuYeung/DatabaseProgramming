using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using GameBackend.Models;

namespace GameBackend.SQLDatabase
{
    public class GetSQLPlayerByID : SQLWrapper
    {
        protected override void SQLCommands()
        {
            string sql = string.Format("SELECT username, first_name, last_name, email, date_of_birth, notification FROM playerdata WHERE idplayerdata = '{0}'", playerData.idplayerdata);

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                playerData.username = rdr.GetString(0);
                playerData.first_name = rdr.GetString(1);
                playerData.last_name = rdr.GetString(2);
                playerData.email = rdr.GetString(3);
                playerData.date_of_birth = rdr.GetString(4);
                playerData.notification = rdr.GetBoolean(5);
            }
            rdr.Close();
        }
    }
}