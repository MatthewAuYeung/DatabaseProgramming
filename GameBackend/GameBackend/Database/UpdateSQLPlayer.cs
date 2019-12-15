using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace GameBackend.Database
{
    public class UpdateSQLPlayer : SQLWrapper
    {
        protected override void SQLCommands()
        {
            string sql = string.Format("UPDATE playerdata SET username = '{0}', first_name = '{1}', last_name = '{2}', email = '{3}', date_of_birth = '{4}', notification = '{5}' WHERE username = '{0}';",
                 playerData.username, playerData.first_name, playerData.last_name, playerData.email, playerData.date_of_birth, playerData.notification);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}