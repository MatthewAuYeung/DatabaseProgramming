﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using GameBackend.Models;

namespace GameBackend.SQLDatabase
{
    public class GetSQLMatchByID : SQLWrapper
    {
        protected override void SQLCommands()
        {
            string sql = string.Format("SELECT score, date_of_match FROM matchdata WHERE playerdata_idplayerdata = '{0}' ORDER BY score DESC LIMIT 10", matchData.idplayerdata);

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            matchDatas = new MatchData[10];

            int count = 0;
            while (rdr.Read())
            {
                matchData.score = rdr.GetInt32(0);
                matchData.date_of_match = rdr.GetString(1);
                matchDatas[count] = matchData;
                ++count;
            }
            rdr.Close();
        }
    }
}