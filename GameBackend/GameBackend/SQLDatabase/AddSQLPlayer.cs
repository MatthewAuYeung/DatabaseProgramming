using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GameBackend.SQLDatabase
{
    public class AddSQLPlayer : SQLWrapper
    {
        protected override void SQLCommands()
        {
            string sql = string.Format("INSERT INTO final.playerdata (username, first_name, last_name, email, date_of_birth, notification) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5})", 
                playerData.username, playerData.first_name, playerData.last_name, playerData.email, playerData.date_of_birth, playerData.notification);

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
