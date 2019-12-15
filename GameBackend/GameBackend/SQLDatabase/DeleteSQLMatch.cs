using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GameBackend.SQLDatabase
{
    public class DeleteSQLMatch : SQLWrapper
    {
        protected override void SQLCommands()
        {
            string sql = string.Format("DELETE FROM matchdata WHERE playerdata_idplayerdata = {0}", matchData.idplayerdata);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}