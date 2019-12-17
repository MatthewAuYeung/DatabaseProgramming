using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GameBackend.SQLDatabase
{
    public class DeleteSQLPlayer : SQLWrapper
    {
        protected override void SQLCommands()
        {
            string sql = string.Format("DELETE FROM playerdata WHERE username = '{0}'", playerData.username);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}