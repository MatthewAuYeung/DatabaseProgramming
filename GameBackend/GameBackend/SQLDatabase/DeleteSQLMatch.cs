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
            string sql = string.Format("DELETE FROM final.matchdata WHERE playerdata_idplayerdata = {0}", matchData.playerdata_idplayerdata);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}