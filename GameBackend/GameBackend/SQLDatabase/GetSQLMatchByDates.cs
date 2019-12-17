﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using GameBackend.Models;

namespace GameBackend.SQLDatabase
{
    public class GetSQLMatchByDates : SQLWrapper
    {
        protected override void SQLCommands()
        {
            string sql = string.Format("SELECT playerdata_idplayerdata, score FROM matchdata WHERE date_of_match BETWEEN '{0}' AND '{1}' ORDER BY score DESC LIMIT 10", start_date, end_date);

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            matchDatas = new MatchData[10];

            int count = 0;
            while (rdr.Read())
            {
                MatchData temp = new MatchData();
                temp.playerdata_idplayerdata = rdr.GetInt32(0);
                temp.score = rdr.GetInt32(1);
                matchDatas[count] = temp;
                ++count;
            }
            rdr.Close();
        }
    }
}