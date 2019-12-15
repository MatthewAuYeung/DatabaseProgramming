using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GameBackend.SQLDatabase
{
    public class AddSQLMatch : SQLWrapper
    {
        protected override void SQLCommands()
        {
            string sql = string.Format("INSERT INTO matchdata (playerdata_idplayerdata, score, date_of_match) VALUES('{0}', '{1}', '{2}')", 
                matchData.idplayerdata, matchData.score, matchData.date_of_match);

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
